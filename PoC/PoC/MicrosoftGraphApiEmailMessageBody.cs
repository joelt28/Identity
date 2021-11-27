using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class MicrosoftGraphApiEmailMessageBody
    {
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}
