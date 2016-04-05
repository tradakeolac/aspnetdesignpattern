using Agathas.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Controllers.ViewModels
{
    public class ProductDetailViewModel : BaseProductCatalogPageViewModel
    {
        public ProductView Product { get; set; }
    }
}
