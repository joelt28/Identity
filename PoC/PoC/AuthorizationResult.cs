using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class AuthorizationResult
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty(PropertyName = "id_token")]
        public string IdToken { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
        [JsonProperty(PropertyName = "error_codes")]
        public int[] ErrorCodes { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public string TimeStamp { get; set; }
        [JsonProperty(PropertyName = "trace_id")]
        public string TraceId { get; set; }
        [JsonProperty(PropertyName = "correlation_id")]
        public string CorrelationId { get; set; }
    }
}
