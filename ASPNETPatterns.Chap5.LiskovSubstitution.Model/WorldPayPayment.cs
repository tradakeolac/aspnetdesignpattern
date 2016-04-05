using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LiskovSubstitution.Model
{
    public class WorldPayPayment : PaymentServiceBase
    {
        public WorldPayPayment(string accountId, string accountPassword, string productId)
        {
            this.AccountId = accountId;
            this.Password = accountPassword;
            this.ProductId = productId;
        }
        public string AccountId { get; set; }
        public string Password { get; set; }
        public string ProductId { get; set; }
        public override RefundResponse Refund(decimal amount, string transactionId)
        {
            RefundResponse refundResponse = new RefundResponse();
            MockWorldPayWebService worldPayWebService = new MockWorldPayWebService();
            string response = worldPayWebService.MakeRefund(amount, transactionId, this.AccountId, this.Password, this.ProductId);
            refundResponse.Message = response;

            if (response.Contains("A_Success"))
                refundResponse.Success = true;
            else
                refundResponse.Success = false;

            return refundResponse;
        }
    }
}
