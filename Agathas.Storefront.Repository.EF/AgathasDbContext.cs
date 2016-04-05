using Agathas.Storefront.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Repository.EF
{
    public class AgathasDbContext : DbContext, IDbContext
    {
        public void Commit()
        {
            base.SaveChanges();
        }

        public DbSet<T> DbSet<T>() where T : AggregateRoot => base.Set<T>();
    }
}
