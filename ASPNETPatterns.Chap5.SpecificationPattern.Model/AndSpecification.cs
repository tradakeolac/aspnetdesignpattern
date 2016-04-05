using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.SpecificationPattern.Model
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _leftSpecification;
        private ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this._leftSpecification = left;
            this._rightSpecification = right;
        }

        public override bool IsStatisfiedBy(T candidate)
        {
            return this._leftSpecification.IsStatisfiedBy(candidate) && this._rightSpecification.IsStatisfiedBy(candidate);
        }
    }
}
