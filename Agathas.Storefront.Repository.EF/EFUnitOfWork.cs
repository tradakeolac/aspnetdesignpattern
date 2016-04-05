using Agathas.Storefront.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Core.Domain;

namespace Agathas.Storefront.Repository.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private Dictionary<AggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<AggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<AggregateRoot, IUnitOfWorkRepository> deletedEntities;

        protected readonly IDbContext DbContext;

        public EFUnitOfWork(IDbContext dbContext)
        {
            this.DbContext = dbContext;

            this.addedEntities = new Dictionary<AggregateRoot, IUnitOfWorkRepository>();
            this.changedEntities = new Dictionary<AggregateRoot, IUnitOfWorkRepository>();
            this.deletedEntities = new Dictionary<AggregateRoot, IUnitOfWorkRepository>();
        }

        public void Commit()
        {
            foreach (AggregateRoot entity in this.addedEntities.Keys)
            {
                this.addedEntities[entity].PersistCreationOf(entity);
            }

            foreach (AggregateRoot entity in this.changedEntities.Keys)
            {
                this.changedEntities[entity].PersistUpdateOf(entity);
            }

            foreach (AggregateRoot entity in this.deletedEntities.Keys)
            {
                this.deletedEntities[entity].PersistDeleteOf(entity);
            }

            this.DbContext.Commit();
        }

        public void RegisterAmended(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!changedEntities.ContainsKey(entity))
                this.changedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterNew(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!this.addedEntities.ContainsKey(entity))
                this.addedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterRemoved(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!this.deletedEntities.ContainsKey(entity))
                this.deletedEntities.Add(entity, unitOfWorkRepository);
        }
    }
}
