using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class MicrosoftGraphApiEmailMessage
    {
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "body")]
        public MicrosoftGraphApiEmailMessageBody Body { get; set; }
        [JsonProperty(PropertyName = "toRecipients")]
        public IList<MicrosoftGraphApiEmailMessageRecipient> ToRecipients { get; set; }
    }
}
