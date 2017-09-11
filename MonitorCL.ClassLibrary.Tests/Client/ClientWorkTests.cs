using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
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
        public void GetLicenseKeyTest_HasKey()
        {
            RegistryKey soft = Registry.CurrentUser.OpenSubKey("SOFTWARE");
            RegistryKey cl = soft.OpenSubKey("CompLife");
            RegistryKey reg = cl.OpenSubKey("MonitorCLClient");
            Assert.IsNotNull(reg);
        }

        [TestMethod()]
        public void GetLicenseKeyTest_HasStringKey()
        {
            RegistryKey soft = Registry.CurrentUser.OpenSubKey("SOFTWARE");
            RegistryKey cl = soft.OpenSubKey("CompLife");
            RegistryKey reg = cl.OpenSubKey("MonitorCLClient");

            if (reg != null)
            {
                Assert.IsNotNull(reg.GetValue("LicenseKey").ToString());
            }
            else
                Assert.Fail();
        }


        [TestMethod()]
        public void GetLicenseKeyTest()
        {
            string key = "11111-11111-11111-11111-11111";
            ClientWork clientWork = new ClientWork();
            string resKey = clientWork.GetLicenseKey();

            Assert.AreEqual(key, resKey);
        }

        [TestMethod()]
        public void SetAutoRunTest_CanOpenKey()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            Assert.IsNotNull(reg);
        }
        [TestMethod()]
        public void SetAutoRunTest_true_get()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (reg != null)
            {
                Assert.AreEqual(reg.GetValue("MonitorCLClient").ToString(), @"D:\MonitorCL\MonitorCLClient\bin\Debug\MonitorCLClient.exe");
            }
            else
                Assert.Fail();
        }
    }
}