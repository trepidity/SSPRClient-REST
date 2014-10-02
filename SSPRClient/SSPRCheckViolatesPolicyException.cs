using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSPRClient
{
    public class SSPRCheckViolatesPolicyException : Exception
    {
        private string p;

        public SSPRCheckViolatesPolicyException(string p) : base(p)
        { }
    }
}
