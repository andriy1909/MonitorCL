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
        MonitoringDB db = new MonitoringDB();

        public AddUserForm()
        {
            InitializeComponent();
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
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            byte[] key = new byte[25];
            rand.GetNonZeroBytes(key);
            foreach (var item in key)
            {
                resultKey += chars[item % chars.Length];
            }
            mtbLicenceKey.Text = resultKey;
            lbNoSave.Visible = true;
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            

            lbNoSave.Visible = false;
        }
    }
}
