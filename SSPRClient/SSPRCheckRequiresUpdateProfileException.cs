using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSPRClient
{
    public class SSPRCheckRequiresUpdateProfileException : Exception
    {
        private string p;

        public SSPRCheckRequiresUpdateProfileException(string p)
            : base(p)
        { }
    }
}
