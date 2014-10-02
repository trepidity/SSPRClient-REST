using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace SSPRClient
{
    static class Program
    {
		static string Main(string[] args)
        {
			if (args == null || args.Length != 1)
				return "Must provide a username to validate";
			SSPRCheck client = new SSPRCheck();
			client.DoCheck(args[0]);
        }
    }
}
