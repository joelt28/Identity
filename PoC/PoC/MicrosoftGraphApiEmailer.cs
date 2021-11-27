using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PoC
{
    public class MicrosoftGraphApiEmailer : EmailerBase
    {
        static readonly HttpClient client = new HttpClient();

        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string TenantID { get; set; }
        private string Scope { get; set; }
        private string AccessToken { get; set; }
        private DateTime AccessTokenExpiry { get; set; }
        protected override void Init()
        {
            base.Init();
            Scope = HttpUtility.UrlEncode("https://graph.microsoft.com/.default");
        }
        public override void Send(Email email)
        {
            throw new NotImplementedException();
        }

        public async override Task SendAsync(Email email)
        {
            //await AuthorizeAsync();
            string endPointUrl = $"https://graph.microsoft.com/v1.0/users/{email.Sender}/sendMail";
            string content = GetPayLoad(email);
            StringContent ContentBody = new StringContent(content, Encoding.UTF8, "application/json");
            ContentBody.Headers.Add("Authorization", $"Bearer {AccessToken}");
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
            MicrosoftGraphApiEmail microsoftGraphApiEmail = GetEmail(email);
            return JsonConvert.SerializeObject(microsoftGraphApiEmail);
        }

        private MicrosoftGraphApiEmail GetEmail(Email email)
        {
            MicrosoftGraphApiEmail emailObj = new MicrosoftGraphApiEmail
            {
                   Message = new MicrosoftGraphApiEmailMessage 
                   {
                        Subject = email.Subject,
                        Body = new MicrosoftGraphApiEmailMessageBody
                        { 
                            ContentType = email.EmailContentType == EmailContentType.HTML ? "Html" : "Text",
                            Content = email.Content
                        },
                        ToRecipients = email.Recipients.Select(o => new MicrosoftGraphApiEmailMessageRecipient 
                        { 
                            EmailAddress = new MicrosoftGraphApiEmailMessageRecipientEmailAddress 
                            { 
                                Address = o 
                            } 
                        }).ToList()
                   }
            };
            return emailObj;
        }

        private async Task AuthorizeAsync()
        {
            if (!string.IsNullOrEmpty(AccessToken) && DateTime.Now < AccessTokenExpiry)
                return;

            string status;
            string endPointUrl = $"https://login.microsoftonline.com/{TenantID}/oauth2/v2.0/token";
            string content = $"grant_type=client_credentials&scope={Scope}&client_id={HttpUtility.UrlEncode(ClientID)}&client_secret={HttpUtility.UrlEncode(ClientSecret)}";
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endPointUrl),
                Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded")
            };
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                status = response.StatusCode.ToString();
                content = await response.Content.ReadAsStringAsync();
                AuthorizationResult authorizationResult = JsonConvert.DeserializeObject<AuthorizationResult>(content);
                AccessToken = authorizationResult.AccessToken;
                AccessTokenExpiry = DateTime.Now.AddSeconds(authorizationResult.ExpiresIn);
            }
        }
    }
}
