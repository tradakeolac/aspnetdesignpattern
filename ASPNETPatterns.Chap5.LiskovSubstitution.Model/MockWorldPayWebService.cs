using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LiskovSubstitution.Model
{
    public class MockWorldPayWebService
    {
        public string MakeRefund(decimal amount, string transactionId, string username, string password, string productId)
        {
            return "A_Success-09901";
        }
    }
}
