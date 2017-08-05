using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class ActivateForm : Form
    {
        public ActivateForm()
        {
            InitializeComponent();
        }

        private void mtbLicenceKey_Leave(object sender, EventArgs e)
        {
            mtbLicenceKey.Text = mtbLicenceKey.Text.ToUpper();
        }

        private void btActivate_Click(object sender, EventArgs e)
        {
            if (mtbLicenceKey.Text.Contains(' '))
            {
                MessageBox.Show("Код активации введен не полностю!");
            }
            else
            {
                SetServerForm setServer = new SetServerForm();
                if (setServer.ShowDialog() == DialogResult.OK)
                {
                    ProgressForm progress = new ProgressForm(mtbLicenceKey.Text);
                    if (progress.ShowDialog()==DialogResult.OK)
                    {
                        DialogResult = DialogResult.OK;
                        Close(); 
                    }
                }
            }
        }
    }
}
