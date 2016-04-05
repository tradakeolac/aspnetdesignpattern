using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Service
{
    public class ErrorLog
    {
        public static string GenerateErrorRefMessageAndLog(Exception exception)
        {
            // Here you would log the error and the unique reference ID
            return string.Format("If you wish to contact us please quote reference '{0}'", Guid.NewGuid());
        }
    }
}
