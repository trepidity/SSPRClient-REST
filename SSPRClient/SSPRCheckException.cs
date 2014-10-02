using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSPRClient
{
    public class SSPRCheckException : Exception
    {
        public SSPRCheckException(string p) : base(p)
        {}
    }
}
