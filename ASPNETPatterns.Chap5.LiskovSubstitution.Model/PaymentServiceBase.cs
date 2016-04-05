using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LiskovSubstitution.Model
{
    public abstract class PaymentServiceBase
    {
        public abstract RefundResponse Refund(decimal amount, string transactionId);
    }
}
