using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Services.Interfaces;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ViewModels;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        public HomeController(IProductCatalogService productCatalogService) : base(productCatalogService)
        {
        }

        public ActionResult Index()
        {
            HomePageViewModel homePageView = new HomePageViewModel();
            homePageView.Categories = base.GetCategories();
            GetFeaturedProductsResponse response =  _productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;
            return View(homePageView);
        }
    }
}
