using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.SpecificationPattern.Model
{
    public interface ISpecification<T>
    {
        bool IsStatisfiedBy(T candidate);

        ISpecification<T> And(ISpecification<T> other);

        ISpecification<T> Not();
    }
}
