using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public interface IDiscountStrategy
    {
        decimal ApplyExtraDiscountsTo(decimal originalSalePrice);
    }
}
