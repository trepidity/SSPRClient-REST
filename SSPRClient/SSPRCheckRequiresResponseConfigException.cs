using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSPRClient
{
    public class SSPRCheckRequiresResponseConfigException : Exception
    {
        private string p;

        public SSPRCheckRequiresResponseConfigException(string p)
            : base(p)
        { }
    }
}
