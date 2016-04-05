using Agathas.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Controllers.ViewModels
{
    public abstract class BaseProductCatalogPageViewModel
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
