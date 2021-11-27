using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class SendGridEmailer : EmailerBase
    {
        static readonly HttpClient client = new HttpClient();
        public string ApiKey { get; set; }
        protected override void Init()
        {
            base.Init();
        }
        public override void Send(Email email)
        {
            throw new NotImplementedException();
        }

        public async override Task SendAsync(Email email)
        {
            string endPointUrl = $"https://api.sendgrid.com/v3/mail/send";
            string content = GetPayLoad(email);
            StringContent ContentBody = new StringContent(content, Encoding.UTF8, "application/json");
            ContentBody.Headers.Add("Authorization", $"Bearer {ApiKey}");
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endPointUrl),
                Content = ContentBody
            };
            HttpResponseMessage response = await client.SendAsync(request);
            string status = null;
            if (response.IsSuccessStatusCode)
            {
                status = response.StatusCode.ToString();
                content = await response.Content.ReadAsStringAsync();
            }
        }

        private string GetPayLoad(Email email)
        {
            return JsonConvert.SerializeObject(GetEmail(email)); ;
        }

        private SendGridEmail GetEmail(Email email)
        {
            SendGridEmail emailObj = new SendGridEmail
            {
               Personalizations = new System.Collections.Generic.List<SendGridEmailPersonalization> { 
                new SendGridEmailPersonalization
                { 
                    Subject = email.Subject,
                    To = new SendGridEmailAddress
                    { 
                        Email = email.Recipients.First()
                    }
                }
               },
               From = new SendGridEmailAddress { Email = email.Sender },
               Content = new SendGridEmailContent { 
                   Type = email.EmailContentType == EmailContentType.HTML ? "text/html" : "text/plain",
                   Value = email.Content
               }
            };
            return emailObj;
        }
    }
}
