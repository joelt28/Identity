using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public class Email
    {
        public EmailContentType EmailContentType { get; set; }
        public string Sender { get; set; }
        public List<string> Recipients { get; set; } 
        public string Subject { get; set; }
        public string Content { get; set; }
        
    }
}
