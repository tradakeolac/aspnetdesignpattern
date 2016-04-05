using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LiskovSubstitution.Model
{
    public class RefundResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
