using Agathas.Storefront.Core.UnitOfWork;
using Agathas.Storefront.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Repository.EF
{
    public class CategoryRepository : Repository<Category, int>
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
