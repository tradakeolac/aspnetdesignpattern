using Agathas.Storefront.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterAmended(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterNew(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterRemoved(AggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void Commit();
    }
}
