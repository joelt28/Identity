using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC
{
    public abstract class EmailerBase : IEmailer
    {
        public EmailerBase()
        {
            Init();
        }
        protected virtual void Init()
        { 
        
        }
        public abstract void Send(Email email);

        public abstract Task SendAsync(Email email);
    }
}
