using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LiskovSubstitution.Model
{
    public class RefundService
    {
        public static RefundResponse Refund(RefundRequest refundRequest)
        {
            PaymentServiceBase paymentService = PaymentServiceFactory.GetPaymentServiceFrom(refundRequest.Payment);

            RefundResponse refundResponse = paymentService.Refund(refundRequest.RefundAmount, refundRequest.PaymentTransactionId);

            return refundResponse;
        }
    }
}
