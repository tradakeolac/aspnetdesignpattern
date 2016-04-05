using Agathas.Storefront.Core.Domain;
using Agathas.Storefront.Core.Quering;
using Agathas.Storefront.Core.UnitOfWork;
using Agathas.Storefront.Repository.NHibernate.Extensions;
using Agathas.Storefront.Repository.NHibernate.SessionStorage;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public abstract class Repository<T, TEntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Remove(T entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }
        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }
        public T FindBy(TEntityKey id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(id);
        }
        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery =
            SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return (List<T>)criteriaQuery.List<T>();
        }
        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery =
            SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return (List<T>)criteriaQuery.SetFetchSize(count)
            .SetFirstResult(index).List<T>();
        }
        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<T>(criteriaQuery);
            return criteriaQuery.List<T>();
        }
        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery =
            SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<T>(criteriaQuery);
            return criteriaQuery.SetFetchSize(count)
                .SetFirstResult(index).List<T>();
        }
        public virtual void AppendCriteria(ICriteria criteria)
        {
        }
    }
}
