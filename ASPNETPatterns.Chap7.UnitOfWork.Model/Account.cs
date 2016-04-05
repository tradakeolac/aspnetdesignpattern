using ASPNETPatterns.Chap7.UnitOfWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.UnitOfWork.Model
{
    public class Account : IAggregateRoot
    {
        public decimal Balance { get; set; }
    }
}
