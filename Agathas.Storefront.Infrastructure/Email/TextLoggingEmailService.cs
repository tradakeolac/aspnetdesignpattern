using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Email
{
    public class TextLoggingEmailService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            StringBuilder email = new StringBuilder();

            email.AppendLine(string.Format("To: {0}", to));
            email.AppendLine(string.Format("From: {0}", from));
            email.AppendLine(string.Format("Subject: {0}", subject));
            email.AppendLine(string.Format("Body: {0}", body));

            Logging.LogginFactory.GetLogger().Log(email.ToString());
        }
    }
}
