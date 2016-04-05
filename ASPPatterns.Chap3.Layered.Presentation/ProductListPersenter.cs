using ASPPatterns.Chap3.Layered.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public class ProductListPersenter
    {
        private IProductListView _productListView;
        private Service.ProductService _productService;

        public ProductListPersenter(IProductListView productListView, Service.ProductService productService)
        {
            this._productListView = productListView;
            this._productService = productService;
        }

        public void Display()
        {
            var request = new ProductListRequest
            {
                CustomerType = this._productListView.CustomerType
            };

            var response = this._productService.GetAllProductsFor(request);

            if (response.Success)
            {
                this._productListView.Display(response.Products);
            }
            else
            {
                this._productListView.ErrorMessage = response.Message;
            }
        }
    }
}
