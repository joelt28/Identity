using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class MicrosoftGraphApiEmailMessageRecipientEmailAddress
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}
