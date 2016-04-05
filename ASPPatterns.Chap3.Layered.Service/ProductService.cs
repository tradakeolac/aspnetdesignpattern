using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Service
{
    public class ProductService
    {
        private Model.ProductService _productService;

        public ProductService(Model.ProductService productService)
        {
            this._productService = productService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            var productListResponse = new ProductListResponse();
            try
            {
                IList<Model.Product> productEntities = this._productService.GetAllProductFor(productListRequest.CustomerType);

                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }
            catch(Exception ex)
            {
                // Log the exception...
                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "An error occurred";
            }

            return productListResponse;
        }
    }
}
