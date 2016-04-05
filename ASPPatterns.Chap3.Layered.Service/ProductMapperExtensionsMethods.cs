using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Service
{
    public static class ProductMapperExtensionsMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Model.Product> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach(var p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }

            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(
                                                    this Model.Product product)
        {
            var productViewModel = new ProductViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                RRP = string.Format("{0:C}", product.Price.RRP),
                SellingPrice = string.Format("{0:C}", product.Price.SellingPrice)
            };

            if (product.Price.Discount > 0)
                productViewModel.Discount = string.Format("{0:C}", product.Price.Discount);
            if (product.Price.Savings < 1 && product.Price.Savings > 0)
                productViewModel.Savings = product.Price.Savings.ToString(@"#%");
            return productViewModel;
        }

    }
}
