using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class Price
    {
        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();
        private decimal _rrp;
        private decimal _sellingPrice;

        public Price(decimal rrp, decimal sellingPrice)
        {
            this._rrp = rrp;
            this._sellingPrice = sellingPrice;
        }

        public void SetDiscountStrategyTo(IDiscountStrategy discountStrategy)
        {
            this._discountStrategy = discountStrategy;
        }

        public decimal SellingPrice
        {
            get { return this._discountStrategy.ApplyExtraDiscountsTo(this._sellingPrice); }
        }

        public decimal RRP
        {
            get { return this._rrp; }
        }

        public decimal Discount
        {
            get
            {
                if (RRP > SellingPrice)
                    return (RRP - SellingPrice);
                return 0;
            }
        }

        public decimal Savings
        {
            get
            {
                if (RRP > SellingPrice)
                    return 1 - (SellingPrice / RRP);
                return 0;
            }
        }
    }
}
