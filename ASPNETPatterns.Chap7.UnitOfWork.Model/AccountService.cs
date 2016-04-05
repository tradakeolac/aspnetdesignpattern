using ASPNETPatterns.Chap7.UnitOfWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.UnitOfWork.Model
{
    public class AccountService
    {
        private IAccountRepository _accountRepository;
        private IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            if(from.Balance >= amount)
            {
                from.Balance -= amount;
                to.Balance += amount;

                this._accountRepository.Save(from);
                this._accountRepository.Save(to);
                this._unitOfWork.Commit();
            }
        }
    }
}
