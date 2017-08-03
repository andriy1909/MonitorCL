using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class BaseBoard : Monitoring
    {
        public override string Fields
        {
            get
            {
                return "";
            }
        }

        public override string GetSign()
        {
            return "BaseBoard";
        }

        public static string GetSerialNumber()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + "SerialNumber" + " FROM Win32_BaseBoard");

            foreach (ManagementObject item in searcher.Get())
            {
                return (string)item["SerialNumber"];
            }

            return null;
        }
    }
}
