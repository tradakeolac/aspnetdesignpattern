using Agathas.Storefront.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(AggregateRoot entity);
        void PersistUpdateOf(AggregateRoot entity);
        void PersistDeleteOf(AggregateRoot entity);
    }
}
