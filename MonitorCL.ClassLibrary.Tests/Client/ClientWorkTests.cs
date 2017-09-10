using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitorCLClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCLClassLibrary.Tests
{
    [TestClass()]
    public class ClientWorkTests
    {
        [TestMethod()]
        public void GetLicenseKeyTest()
        {
            string key = "11111-11111-11111-11111-11111";
            ClientWork clientWork = new ClientWork();
            string resKey = clientWork.GetLicenseKey();

            Assert.AreEqual(key, resKey);
        }
    }
}