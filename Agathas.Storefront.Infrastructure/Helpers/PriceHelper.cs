using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price) => $"{price}";
    }
}
