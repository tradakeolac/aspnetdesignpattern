using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap8.FrontController.Controller.Request;
using ASPNETPatterns.Chap8.FrontController.Controller.Storage;
using ASPNETPatterns.Chap8.FrontController.StubRepository;

namespace ASPNETPatterns.Chap8.FrontController.Controller.ActionCommands
{
    public class GetTopSellingProductsCommand : IActionCommand
    {
        private IViewStorage _storage;
        private ProductService _productService;

        public GetTopSellingProductsCommand(IViewStorage storage, ProductService productService)
        {
            this._storage = storage;
            this._productService = productService;
        }

        public void Process(WebRequest request)
        {
            this._storage.Add(ViewStorageKeys.Products, this._productService.GetBestSellingProducts());
        }
    }
}
