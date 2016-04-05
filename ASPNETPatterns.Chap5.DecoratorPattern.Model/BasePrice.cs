using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.DecoratorPattern.Model
{
    class BasePrice : IPrice
    {
        public decimal Cost { get; set; }
    }
}
