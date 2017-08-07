using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MonitorCLClassLibrary.Model;

namespace MonitorCLServer
{
    public partial class AddUserForm : Form
    {
        UsersGroup parentGroup = null;
        MonitoringDB db = new MonitoringDB();

        public AddUserForm(UsersGroup parentGroup = null)
        {
            InitializeComponent();
            this.parentGroup = parentGroup;
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(mtbLicenceKey.Text);
        }

        private void btOK_Click(object sender, EventArgs e)
        {

        }

        private void btGenereteKey_Click(object sender, EventArgs e)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string resultKey = "";
            do
            {
                resultKey = "";
                RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
                byte[] key = new byte[25];
                rand.GetNonZeroBytes(key);
                foreach (var item in key)
                {
                    resultKey += chars[item % chars.Length];
                }

            } while (db.LicenceKeys.SingleOrDefault(x=>x.Key==resultKey)!=null);
            mtbLicenceKey.Text = resultKey;
            lbNoSave.Visible = true;
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserName = tbUserName.Text,
                DateReg = DateTime.Now,
                Group = parentGroup,
                Information = tbInformation.Text,
                TypePC = cbTypeDevice.Text,
                Phone = mtbPhone.Text,
                Company = tbCompany.Text
            };
            db.Users.Add(user);
            db.SaveChanges();
            LicenceKey licenseKey = new LicenceKey()
            {
                Active = true,
                DateExp = dtpDateTo.Value,
                Key = mtbLicenceKey.Text,
                User = user,
                DateCreate = DateTime.Now,
                UnicId = null
            };
            db.LicenceKeys.Add(licenseKey);
            db.SaveChanges();                

            lbNoSave.Visible = false;
        }
    }
}
