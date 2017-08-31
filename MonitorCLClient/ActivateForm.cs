using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

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
