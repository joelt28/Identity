using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    [JsonObject()]
    public class MicrosoftGraphApiEmailMessageRecipient
    {
        [JsonProperty(PropertyName = "emailAddress")]
        public MicrosoftGraphApiEmailMessageRecipientEmailAddress EmailAddress { get; set; }
    }
}
