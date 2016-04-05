using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.SpecificationPattern.Model
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _innerSpecification;
        public NotSpecification(ISpecification<T> innerSpecification)
        {
            this._innerSpecification = innerSpecification;
        }

        public override bool IsStatisfiedBy(T candidate)
        {
            return !this._innerSpecification.IsStatisfiedBy(candidate);
        }
    }
}
