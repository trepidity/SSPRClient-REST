using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SSPRClient
{
    [TestClass]
    public class UnitTest1
    {
        string username = "testuser";

        [TestMethod]
        public void TestValidAccountSuccess()
        {
            SSPRCheck client = new SSPRCheck ();
            Assert.AreEqual(0, client.DoCheck(username));
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestCheckResponseSetSetupRequired()
        {
            SSPRCheck client = new SSPRCheck();
            Assert.AreEqual(typeof(SSPRCheckRequiresResponseConfigException), client.DoCheck("expiredTestUser").GetType());
        }
    }
}
