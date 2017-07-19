using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management;
using System.Text;

namespace MonitorCLClassLibrary
{
    public class Product : Monitoring
    {
        /// <summary>
        /// Ключ в базе данных
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Название программы.
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// Идентификация продукта, такая как серийный номер программного обеспечения, или номер штампа на аппаратном чипе.
        /// </summary>
        public string IdentifyingNumber { get; protected set; }
        /// <summary>
        /// Дата, когда этот продукт был установлен в системе.
        /// </summary>
        public DateTime InstallDate { get; protected set; }
        /// <summary>
        /// Расположение установленного продукта.
        /// </summary>
        public string InstallLocation { get; protected set; }
        /// <summary>
        /// Название поставщика продукта. 
        /// </summary>
        public string Vendor { get; protected set; }
        /// <summary>
        /// Версия
        /// </summary>
        public string Version { get; protected set; }

        public override string Fields
        {
            get
            {
                return "Name;IdentifyingNumber;InstallDate;InstallLocation;Vendor;Version";
            }
        }

        public string getDesc()
        {
            return "Название;Идентификатор;Дата установки;Расположение;Поставщик;Версия";
        }

        public override string GetSign()
        {
            return "Product";
        }

        public List<Product> GetData()
        {
            List<Product> list = new List<Product>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + "Caption,IdentifyingNumber,InstallDate,InstallLocation,Vendor,Version,InstallDate2" + " FROM Win32_Product");

            foreach (ManagementObject item in searcher.Get())
            {
                list.Add(new Product()
                {
                    Name = (string)item["Caption"],
                    IdentifyingNumber = (string)item["IdentifyingNumber"],
                    InstallDate = ((string)item["InstallDate2"] == null) ? ConvertDate((string)item["InstallDate"]) : ConvertDate((string)item["InstallDate2"]),
                    InstallLocation = (string)item["InstallLocation"],
                    Vendor = (string)item["Vendor"],
                    Version = (string)item["Version"]
                });
            }
            return list;
        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Name": return Name;
                    case "IdentifyingNumber": return IdentifyingNumber;
                    case "InstallDate": return InstallDate;
                    case "InstallLocation": return InstallLocation;
                    case "Vendor": return Vendor;
                    case "Version": return Version;
                    default:
                        return null;
                }
            }
            protected set
            {
                switch (name)
                {
                    case "Name": Name = (string)value; break;
                    case "IdentifyingNumber": IdentifyingNumber = (string)value; break;
                    case "InstallDate": InstallDate = ConvertDate((string)value); break;
                    case "InstallLocation": InstallLocation = (string)value; break;
                    case "Vendor": Vendor = (string)value; break;
                    case "Version": Version = (string)value; break;
                    default:
                        break;
                }
            }
        }
    }
}
