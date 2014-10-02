// Example of calling SSPR for account status.
// with this class, you can determine
// * if a users password is expired
// * if the user has setup their Challenge Response
// * other items as needed
//
// Author: Jared Jennings
// Date: Oct 1, 2014
// All rights reserved by Novacoast, Inc.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SSPRClient
{
    public class SSPRCheck
    {
        //The domain where SSPR/PWM runs.
		const string ssprURL = "https://sspr.example.com";
		// this must be changed to /pwm/... if using PWM instead of SSPR.
		const string api_url = "/sspr/public/rest/status?username={0}";
        // to use REST services in SSPR, you must have a service account configured with rights to the REST module
        const string ssprProxyUser = "cn=sspr_proxy,ou=services,DC=EXAMPLE,DC=COM";
        const string ssprProxyPassword = "SomethingReallyAwesome";

        int ssprStatusCode = -1;
        string user;

        public int DoCheck(string username)
        {
            user = username;
            RunAsync().Wait();
            return ssprStatusCode;
        }

        async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                // setup basic authentication to SSPR
                client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", ssprProxyUser, ssprProxyPassword))));
                client.BaseAddress = new Uri(ssprURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // endpoints could change, but this is the most common and gets everything we need.
				HttpResponseMessage resp = await client.GetAsync(String.Format(api_url, user));

                // make sure the client knows that we want only success codes
                resp.EnsureSuccessStatusCode();

                if (resp.IsSuccessStatusCode)
                {
                    RootObject rootObj = await resp.Content.ReadAsAsync<RootObject>();

                    // debug
                    Console.WriteLine("SSPR Error Code {0}", rootObj.errorCode);
                    
                    // SSPR documentation has many error codes. 0 means that we were able to authenticate to the site.
                    ssprStatusCode = rootObj.errorCode;

                    if (rootObj.data.requiresResponseConfig) // BOO the user hasn't setup their challenge questions and answers
                        throw new SSPRCheckRequiresResponseConfigException("User has not configured their Challenge Responses");
                    if (rootObj.data.requiresUpdateProfile)
                        throw new SSPRCheckRequiresUpdateProfileException("User hasn't completed their SSPR profile. Maybe they are missing some attribute");
                    if (rootObj.data.passwordStatus.violatesPolicy)
                        throw new SSPRCheckViolatesPolicyException("The users password failed to meet the password requirements");
                }
            }
        }
    }
}
