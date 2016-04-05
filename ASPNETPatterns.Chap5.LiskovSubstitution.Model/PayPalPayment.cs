using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LiskovSubstitution.Model
{
    public class PayPalPayment : PaymentServiceBase
    {
        public PayPalPayment(string accountName, string password)
        {
            this.AccountName = accountName;
            this.Password = password;
        }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public override RefundResponse Refund(decimal amount, string transactionId)
        {
            MockPayPayWebService payPalWebService = new MockPayPayWebService();
            RefundResponse refundResponse = new RefundResponse();
            string token = payPalWebService.ObtainToken(this.AccountName, this.Password);
            string response = payPalWebService.MakeRefund(amount, transactionId, token);
            refundResponse.Message = response;

            if (response.Contains("Auth"))
                refundResponse.Success = true;
            else
                refundResponse.Success = false;

            return refundResponse;            
        }
    }
}
