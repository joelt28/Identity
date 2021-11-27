using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class SendGridEmail
    {
        [JsonProperty(PropertyName = "personalizations")]
        public List<SendGridEmailPersonalization> Personalizations { get; set; }
        [JsonProperty(PropertyName = "from")]
        public SendGridEmailAddress From { get; set; }
        [JsonProperty(PropertyName = "content")]
        public SendGridEmailContent Content { get; set; }
    }
}
