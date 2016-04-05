using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ASPPatterns.Chap2.Service
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private ICacheStorage _cacheStorage;

        public ProductService(IProductRepository productRepository, ICacheStorage cacheStorage)
        {
            this._productRepository = productRepository;
            this._cacheStorage = cacheStorage;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products;
            var storageKey = $"products_in_category_id_{categoryId}";

            products = this._cacheStorage.Retrieve<List<Product>>(storageKey);

            if(products == null)
            {
                products = this._productRepository.GetAllProductsIn(categoryId);
                this._cacheStorage.Store(storageKey, products);
            }

            return products;
        }
    }
}
