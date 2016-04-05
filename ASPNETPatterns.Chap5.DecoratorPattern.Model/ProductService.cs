using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DecoratorPattern.Model
{
    class ProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository repository)
        {
            this._productRepository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = this._productRepository.FindAll();
            products.ApplyTradeDiscount();

            products.ApplyCurrentMultiplier();

            return products;
        }
    }
}
