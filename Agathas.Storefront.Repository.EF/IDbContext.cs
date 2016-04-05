using Agathas.Storefront.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Repository.EF
{
    public interface IDbContext : IObjectContextAdapter
    {
        void Commit();
        DbSet<T> DbSet<T>() where T : AggregateRoot;
    }
}
