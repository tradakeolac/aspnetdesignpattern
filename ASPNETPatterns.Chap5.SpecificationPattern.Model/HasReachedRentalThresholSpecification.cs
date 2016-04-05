using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.SpecificationPattern.Model
{
    public class HasReachedRentalThresholSpecification : CompositeSpecification<CustomerAccount>
    {
        public override bool IsStatisfiedBy(CustomerAccount candidate)
        {
            return candidate.NumberOfRentalsThisMonth >= 5;
        }
    }
}
