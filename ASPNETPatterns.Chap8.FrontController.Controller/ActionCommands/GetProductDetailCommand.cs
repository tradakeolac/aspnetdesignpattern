using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap8.FrontController.Controller.Request;
using ASPNETPatterns.Chap8.FrontController.Controller.Storage;
using ASPNETPatterns.Chap8.FrontController.StubRepository;
using ASPNETPatterns.Chap8.FrontController.Model;

namespace ASPNETPatterns.Chap8.FrontController.Controller.ActionCommands
{
    public class GetProductDetailCommand : IActionCommand
    {
        private readonly IViewStorage _storage;
        private readonly ProductService _productService;

        public GetProductDetailCommand(IViewStorage storage, ProductService productService)
        {
            this._storage = storage;
            this._productService = productService;
        }

        public void Process(WebRequest request)
        {
            int productId = ActionArguments.ProductId.ExtractFrom(request.QueryArguments);

            Product product = this._productService.GetProductBy(productId);

            this._storage.Add(ViewStorageKeys.Product, product);
        }
    }
}
