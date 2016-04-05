using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DependencyInjection.Model
{
    public class Product
    {
        public void AdjustPriceWith(IProductDiscountStrategy discount)
        {

        }
    }
}
