using Agathas.Storefront.Controllers.ViewModels;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.JsonDTOs;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class ProductController : ProductCatalogBaseController
    {
        public ProductController(IProductCatalogService productService) : base(productService)
        {
        }
        public ActionResult GetProductsByCategory(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest =
            GenerateInitialProductSearchRequestFrom(categoryId);
            GetProductsByCategoryResponse response =
            this._productCatalogService.GetProductsByCategory(productSearchRequest);
            ProductSearchResultViewModel ProductSearchResultViewModel =
            GetProductSearchResultViewModelFrom(response);
            return View("ProductSearchResults", ProductSearchResultViewModel);
        }
        private ProductSearchResultViewModel GetProductSearchResultViewModelFrom(
        GetProductsByCategoryResponse response)
        {
            ProductSearchResultViewModel ProductSearchResultViewModel =
            new ProductSearchResultViewModel();
            ProductSearchResultViewModel.Categories = base.GetCategories();
            ProductSearchResultViewModel.CurrentPage = response.CurrentPage;
            ProductSearchResultViewModel.NumberOfTitlesFound =
            response.NumberOfTitlesFound;
            ProductSearchResultViewModel.Products = response.Products;
            ProductSearchResultViewModel.RefinementGroups = response.RefinementGroups;
            ProductSearchResultViewModel.SelectedCategory = response.SelectedCategory;
            ProductSearchResultViewModel.SelectedCategoryName =
            response.SelectedCategoryName;
            ProductSearchResultViewModel.TotalNumberOfPages =
            response.TotalNumberOfPages;
            return ProductSearchResultViewModel;
        }
        private static GetProductsByCategoryRequest
        GenerateInitialProductSearchRequestFrom(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest =
   new GetProductsByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = int.Parse(
            ApplicationSettingFactory.GetApplicationSettings().NumberOfResultsPerPage);
            productSearchRequest.CategoryId = categoryId;
            productSearchRequest.Index = 1;
            productSearchRequest.SortBy = ProductsSortBy.PriceHighToLow;
            return productSearchRequest;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProductsByAjax(
        JsonProductSearchRequest jsonProductSearchRequest)
        {
            GetProductsByCategoryRequest productSearchRequest =
            GenerateProductSearchRequestFrom(jsonProductSearchRequest);
            GetProductsByCategoryResponse response =
            _productCatalogService.GetProductsByCategory(productSearchRequest);
            ProductSearchResultViewModel ProductSearchResultViewModel =
            GetProductSearchResultViewModelFrom(response);
            return Json(ProductSearchResultViewModel);
        }
        private static GetProductsByCategoryRequest GenerateProductSearchRequestFrom(JsonProductSearchRequest jsonProductSearchRequest)
        {
            GetProductsByCategoryRequest productSearchRequest =
            new GetProductsByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = int.Parse(ApplicationSettingFactory
            .GetApplicationSettings().NumberOfResultsPerPage);
            productSearchRequest.Index = jsonProductSearchRequest.Index;
            productSearchRequest.CategoryId = jsonProductSearchRequest.CategoryId;
            productSearchRequest.SortBy = jsonProductSearchRequest.SortBy;
            List<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            RefinementGroup refinementGroup;
            foreach (JsonRefinementGroup jsonRefinementGroup in
            jsonProductSearchRequest.RefinementGroups)
            {
                switch ((RefinementGroupings)jsonRefinementGroup.GroupId)
                {
                    case RefinementGroupings.brand:
                        productSearchRequest.BrandIds =
                        jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.color:
                        productSearchRequest.ColorIds =
                        jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.size:
                        productSearchRequest.SizeIds =
                        jsonRefinementGroup.SelectedRefinements;
                        break;
                    default:
                        break;
                }
            }
            return productSearchRequest;
        }

        public ActionResult Detail(int id)
        {
            ProductDetailViewModel productDetailView = new ProductDetailViewModel();
            GetProductRequest request = new GetProductRequest() { ProductId = id };
            GetProductResponse response = _productCatalogService.GetProduct(request);
            ProductView productView = response.Product;
            productDetailView.Product = productView;
            productDetailView.Categories = base.GetCategories();
            return View(productDetailView);
        }
    }
}
