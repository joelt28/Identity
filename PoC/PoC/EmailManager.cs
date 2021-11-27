using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class EmailManager
    {
        private static IEmailer sharedInstance = null;
        private static readonly object lockObj = new object();
        public static async Task SendAsync(Email email) 
        {
            IEmailer mSharedInstance = GetSharedEmailer();
            if (mSharedInstance != null)
            {
                await mSharedInstance.SendAsync(email);
            }
        }

        public static IEmailer GetSharedEmailer()
        {
            if (sharedInstance == null) 
            {
                lock (lockObj)
                {
                    if (sharedInstance == null)
                    {
                        //TODO Get default emailer type from configuration
                        sharedInstance = GetEmailer(EmailerType.SENDGRID);
                    }
                }
            }
            return sharedInstance;
        }

        public static IEmailer GetEmailer(EmailerType emailerType) 
        {
            switch (emailerType)
            {
                case EmailerType.MICROSOFT_GRAPH_API:
                    return new MicrosoftGraphApiEmailer();
                case EmailerType.SENDGRID:
                    return new SendGridEmailer();
                case EmailerType.SMTP:
                default:
                    return new SmtpEmailer();
            }
        }
    }
}
