using Agathas.Storefront.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Core.Quering;
using Agathas.Storefront.Core.UnitOfWork;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Category> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}
