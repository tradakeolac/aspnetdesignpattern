using Agathas.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Core.UnitOfWork;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class ProductTitleRepository : Repository<ProductTitle, int>, IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
