using Agathas.Storefront.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Core.Domain;
using NHibernate;
using Agathas.Storefront.Repository.NHibernate.SessionStorage;

namespace Agathas.Storefront.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void RegisterAmended(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }
    }
}
