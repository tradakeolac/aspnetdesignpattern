using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DecoratorPattern.Model
{
    class CurrencyPriceDecorator : IPrice
    {
        private IPrice _basePrice;
        private decimal _exchangeRate;

        public CurrencyPriceDecorator(IPrice price, decimal exchangeRate)
        {
            this._basePrice = price;
            this._exchangeRate = exchangeRate;
        }

        public decimal Cost
        {
            get { return this._basePrice.Cost * this._exchangeRate; }
            set { this._basePrice.Cost = value; }
        }
    }
}
