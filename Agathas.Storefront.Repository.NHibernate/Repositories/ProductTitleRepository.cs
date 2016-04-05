using Agathas.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Core.UnitOfWork;
using NHibernate;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class ProductTitleRepository : Repository<ProductTitle, int>, IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("Title", "ProductTitle");
            criteria.CreateAlias("ProductTitle.Category", "Category");
            criteria.CreateAlias("ProductTitle.Brand", "Brand");
            criteria.CreateAlias("ProductTitle.Color", "Color");
        }
    }
}
