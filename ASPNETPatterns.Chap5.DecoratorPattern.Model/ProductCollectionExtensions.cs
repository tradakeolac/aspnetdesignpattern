using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DecoratorPattern.Model
{
    static class ProductCollectionExtensions
    {
        public static void ApplyCurrentMultiplier(this IEnumerable<Product> products)
        {
            foreach (var product in products)
                product.Price = new CurrencyPriceDecorator(product.Price, 0.78m);
        }

        public static void ApplyTradeDiscount(this IEnumerable<Product> products)
        {
            foreach (var product in products)
                product.Price = new TradeDiscountPriceDecorator(product.Price);
        }
    }
}
