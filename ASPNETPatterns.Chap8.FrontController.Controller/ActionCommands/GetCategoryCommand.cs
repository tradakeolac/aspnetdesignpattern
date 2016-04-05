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
    public class GetCategoryCommand : IActionCommand
    {
        private IViewStorage _storage;
        private ProductService _productService;

        public GetCategoryCommand(IViewStorage storage, ProductService productService)
        {
            this._storage = storage;
            this._productService = productService;
        }

        public void Process(WebRequest request)
        {
            int categoryId = ActionArguments.CategoryId.ExtractFrom(request.QueryArguments);

            Category category = this._productService.GetCategoryBy(categoryId);

            this._storage.Add(ViewStorageKeys.Category, category);
        }
    }
}
