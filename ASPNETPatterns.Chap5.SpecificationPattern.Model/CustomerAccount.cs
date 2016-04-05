using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.SpecificationPattern.Model
{
    public class CustomerAccount
    {
        private ISpecification<CustomerAccount> _hasReachedRentalThreshold;
        private ISpecification<CustomerAccount> _customerAccountIsActive;
        private ISpecification<CustomerAccount> _customerAccountHasLateFees;

        public CustomerAccount()
        {
            this._hasReachedRentalThreshold = new HasReachedRentalThresholSpecification();
            this._customerAccountIsActive = new CustomerAccountStillActiveSpecification();
            this._customerAccountHasLateFees = new CustomerAccountHasLateFeesSpecification();
        }

        public decimal NumberOfRentalsThisMonth { get; set; }

        public bool AccountActive { get; set; }

        public decimal LateFees { get; set; }

        public bool CanRent()
        {
            var canRent = this._customerAccountIsActive.And(this._hasReachedRentalThreshold.Not())
                                                       .And(this._customerAccountHasLateFees.Not());

            return canRent.IsStatisfiedBy(this);
        }
    }
}
