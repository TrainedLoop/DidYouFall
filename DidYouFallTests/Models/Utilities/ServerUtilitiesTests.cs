using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DidYouFall.Models.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using DidYouFall.Repository;
namespace DidYouFall.Models.Utilities.Tests
{
    [TestClass()]
    public class ServerUtilitiesTests
    {
        [TestMethod()]
        public void CheckServerTest_GoogleTest()
        {
            var a = ServerUtilities.SendPing("google.com");
            Assert.AreEqual("Online", a.Status);
        }
         [TestMethod()]
        public void CheckServerTest_LocalTest()
        {
            var a = ServerUtilities.SendPing("localhost");
            Assert.AreEqual("Online", a.Status);
        }

        [TestMethod()]
         public void CheckServerTest_ToOfflineHost()
         {
             var a = ServerUtilities.SendPing("10.0.0.50");
             Assert.AreEqual("Offline", a.Status);
         }
    }
}
