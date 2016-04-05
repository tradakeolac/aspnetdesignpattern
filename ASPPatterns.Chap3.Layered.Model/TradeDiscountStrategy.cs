using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class TradeDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal originalSalePrice)
        {
            return originalSalePrice * 0.95M;
        }
    }
}
