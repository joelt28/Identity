using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class SendGridEmailPersonalization
    {
        [JsonProperty(PropertyName = "to")]
        public SendGridEmailAddress To { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
    }
}
