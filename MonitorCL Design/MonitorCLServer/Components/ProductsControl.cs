using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace MonitorCLServer
{
    public partial class ProductsControl : UserControl
    {
        string type = "os";

        public ProductsControl()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        public void setColor(int row, Color color)
        {
            dataGridView1.Rows[row].DefaultCellStyle.BackColor = color;
        }


        public ProductsControl(string types)
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
            type = types;
        }

        string[] fields = "Назва;Ідентифікатор;Дата установки;Розміщення;Постачальний;Версія".Split(';');

        private void ProductsControl_Load(object sender, EventArgs e)
        {
          /*  switch (type)
            {
                case "os":
                    Product product = new Product();
                    var list = product.GetData();

                    foreach (var item in fields)
                    {
                        dataGridView1.Columns.Add("cl" + new Random().Next(100000).ToString(), item);
                    }

                    foreach (var item in list)
                    {
                        dataGridView1.Rows.Add(new object[] {
                    imageList1.Images[new Random().Next(25)],
                    item.Name,
                item.IdentifyingNumber,
                item.InstallDate,
                item.InstallLocation,
                item.Vendor,
                item.Version
                });
                    }
                    break;
                case "au":
                    dataGridView1.Columns.Add("Caption", "Назва");
                    dataGridView1.Columns.Add("Command", "Команда");
                    dataGridView1.Columns.Add("Description", "Опис");
                    dataGridView1.Columns.Add("Location", "Розміщення");
                    dataGridView1.Columns.Add("User", "Користувач");

                    SelectQuery query = new SelectQuery("SELECT * FROM Win32_StartupCommand");
                    ManagementObjectSearcher items = new ManagementObjectSearcher(query);
                    foreach (ManagementObject item in items.Get())
                    {
                        dataGridView1.Rows.Add(new object[] {
                            imageList1.Images[new Random().Next(25)],
                    item["Caption"],
                    item["Command"],
                    item["Description"],
                    item["Location"],
                    item["User"]
                });
                    }
                    break;
                default:
                    break;
            }
            */
        }



        public class Product
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

            public string Fields
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

            public string GetSign()
            {
                return "Product";
            }

            public List<Product> GetData()
            {
                List<Product> list = new List<Product>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + "Caption,IdentifyingNumber,InstallDate,InstallLocation,Vendor,Version,InstallDate2" + " FROM Win32_Product");
                int i = 0;
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
                    i++;
                    if (i >= 20)
                        break;
                }
                return list;
            }

            protected DateTime ConvertDate(string value)
            {
                if (value == "" || value == null || value.Length < 8)
                    return DateTime.MinValue;
                if (value.Length > 8)
                {
                    value = value.Remove(14);
                    value = value.Insert(12, ":");
                    value = value.Insert(10, ":");
                    value = value.Insert(8, " ");
                }
                value = value.Insert(6, ".");
                value = value.Insert(4, ".");

                DateTime date = DateTime.Parse(value);
                return date;
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
}
