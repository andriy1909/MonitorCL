using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class NetworkAdapter : Monitoring
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

        public List<NetworkAdapter> GetData()
        {
            List<NetworkAdapter> list = new List<NetworkAdapter>();

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection col = mc.GetInstances();
            foreach (ManagementObject mo in col)
            {
                string macAddr = mo["MACAddress"] as string;
                if (macAddr != null && macAddr.Trim() != "")
                    Console.WriteLine(macAddr);
            }

            return list;
        }
    }
}
