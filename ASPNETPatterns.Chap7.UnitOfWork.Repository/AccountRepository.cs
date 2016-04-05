using ASPNETPatterns.Chap7.UnitOfWork.Infrastructure;
using ASPNETPatterns.Chap7.UnitOfWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.UnitOfWork.Repository
{
    public class AccountRepository : IAccountRepository, IUnitOfWorkRepository
    {
        private IUnitOfWork _unitOfWork;

        public AccountRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Add(Account account)
        {
            this._unitOfWork.RegisterNew(account, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            // ADO.NET code here to add the entity...
        }

        public void PersistDeleteOf(IAggregateRoot entity)
        {
            // ADO.NET code here to delete the entity...
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            // ADO.NET code here to update the entity...
        }

        public void Remove(Account account)
        {
            this._unitOfWork.RegisterRemove(account, this);
        }

        public void Save(Account account)
        {
            this._unitOfWork.RegisterAmended(account, this);
        }
    }
}
