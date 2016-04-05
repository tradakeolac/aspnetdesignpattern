using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DependencyInjection.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsAndApplyDiscount(IProductDiscountStrategy discount)
        {
            var products = this._productRepository.FindAll();

            foreach (var p in products)
                p.AdjustPriceWith(discount);

            return products;
        }
    }
}
