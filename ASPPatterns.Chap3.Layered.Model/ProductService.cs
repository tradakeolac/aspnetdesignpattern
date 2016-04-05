using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IList<Product> GetAllProductFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);

            IList<Product> products = this._productRepository.FindAll();

            products.Apply(discountStrategy);

            return products;
        }
    }
}
