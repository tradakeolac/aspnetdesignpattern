using Agathas.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Controllers.ViewModels
{
    public class ProductSearchResultViewModel : BaseProductCatalogPageViewModel
    {
        public ProductSearchResultViewModel()
        {
            this.RefinementGroups = new List<RefinementGroup>();
        }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        public int SelectedCategory { get; set; }
        public string SelectedCategoryName { get; set; }
        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
