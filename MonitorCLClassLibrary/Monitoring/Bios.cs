using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class Bios : Monitoring
    {
        public override string Fields
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string GetSign()
        {
            throw new NotImplementedException();
        }

        public static string GetSerialNumber()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + "SerialNumber" + " FROM Win32_BIOS");

            foreach (ManagementObject item in searcher.Get())
            {
                return (string)item["SerialNumber"];
            }

            return null;
        }
    }
}
