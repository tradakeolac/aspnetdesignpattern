using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DecoratorPattern.Model
{
    class TradeDiscountPriceDecorator : IPrice
    {
        private IPrice _basePrice;

        public TradeDiscountPriceDecorator(IPrice price)
        {
            this._basePrice = price;
        }

        public decimal Cost
        {
            get { return this._basePrice.Cost * 0.95m; }
            set { this._basePrice.Cost = value; }
        }
    }
}
