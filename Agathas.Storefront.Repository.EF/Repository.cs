using Agathas.Storefront.Core.Domain;
using Agathas.Storefront.Core.Quering;
using Agathas.Storefront.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;

namespace Agathas.Storefront.Repository.EF
{
    public abstract class Repository<TEntity, TEntityKey> where TEntity : AggregateRoot
    {
        private readonly PluralizationService _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
        protected readonly IUnitOfWork UnitOfWork;
        private IDbContext DbContext;

        protected Repository(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IQueryable<TEntity> GetQuery()
        {
            /*  
             * From CTP4, I could always safely call this to return an IQueryable on DbContext  
             * then performed any with it without any problem: 
             */
            // return DbContext.DbSet<TEntity>(); 

            /* 
             * but with 4.1 release, when I call GetQuery<TEntity>().AsEnumerable(), there is an exception: 
             * ... System.ObjectDisposedException : The ObjectContext instance has been disposed and can no longer be used for operations that require a connection. 
             */

            // here is a work around:  
            // - cast DbContext to IObjectContextAdapter then get ObjectContext from it 
            // - call CreateQuery<TEntity>(entityName) method on the ObjectContext 
            // - perform querying on the returning IQueryable, and it works! 
            var entityName = GetEntityName<TEntity>();
            return ((IObjectContextAdapter)DbContext).ObjectContext.CreateQuery<TEntity>(entityName);
        }
        
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.DbContext.DbSet<TEntity>().Add(entity);
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            DbContext.DbSet<TEntity>().Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.DbSet<TEntity>().Remove(entity);
        }


        public IEnumerable<TEntity> GetAll() => this.GetQuery().AsEnumerable();

        public TEntity Save(TEntity entity)
        {
            Add(entity);
            DbContext.Commit();
            return entity;
        }

        public void Update(TEntity entity)
        {
            var fqen = GetEntityName<TEntity>();

            object originalItem;
            var key = DbContext.ObjectContext.CreateEntityKey(fqen, entity);
            if (DbContext.ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                DbContext.ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
            }
        }

        public TEntity GetByKey(TEntityKey id)
        {
            EntityKey key = GetEntityKey(id);

            object originalItem;
            if (DbContext.ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return this.GetQuery().AsEnumerable();
        }

        public IEnumerable<TEntity> FindAll(int index, int count)
        {
            return this.GetQuery().Skip(index).Take(count).AsEnumerable();
        }

        public IEnumerable<TEntity> FindBy(Query query)
        {
            return null;
        }

        public int Count()
        {
            return GetQuery().Count();
        }
        
        private EntityKey GetEntityKey(object keyValue)
        {
            var entityDbSetName = GetEntityName<TEntity>();
            var objectDbSet = DbContext.ObjectContext.CreateObjectSet<TEntity>();
            var keyPropertyName = objectDbSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entityDbSetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }

        private string GetEntityName<TEntity>()
        {
            return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, _pluralizer.Pluralize(typeof(TEntity).Name));
        }
    }
}
