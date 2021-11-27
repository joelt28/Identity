using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class SmtpEmailer : EmailerBase
    {
        SmtpClient SmtpClient { get; set; }
        protected override void Init()
        {
            base.Init();
            //TODO Get parameters from configuration file
            SmtpClient = new SmtpClient();
            SmtpClient.Port = 25;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Host = ""; 
        }
        public override void Send(Email email)
        {
            throw new NotImplementedException();
        }

        public async override Task SendAsync(Email email)
        {
            using (var mailMessage = new MailMessage(email.Sender, email.Recipients.First())) 
            {
                mailMessage.IsBodyHtml = email.EmailContentType == EmailContentType.HTML;
                mailMessage.Subject = email.Subject;
                mailMessage.Body = email.Content;
                await SmtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
