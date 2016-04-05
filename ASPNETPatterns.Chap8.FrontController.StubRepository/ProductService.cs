using ASPNETPatterns.Chap8.FrontController.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.StubRepository
{
    public class ProductService
    {
        public IEnumerable<Product> GetBestSellingProducts()
        {
            return null;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return null;
        }

        public Product GetProductBy(int id)
        {
            return null;
        }

        public IEnumerable<Product> GetAllProductsIn(int categoryId)
        {
            return null;
        }

        public Category GetCategoryBy(int id)
        {
            return null;
        }
    }
}
