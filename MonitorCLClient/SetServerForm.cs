using System;
using System.Net;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class SetServerForm : Form
    {
        public string IP
        {
            get
            {
                return tbIPAddress.Text;
            }
        }
        public int Port
        {
            get
            {
                return (int)numPort.Value;
            }
        }

        public SetServerForm()
        {
            InitializeComponent();
        }

        private void SetServerForm_Load(object sender, EventArgs e)
        {
            tbIPAddress.Text = Properties.Settings.Default.ip;
            numPort.Value = Properties.Settings.Default.port;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            IPAddress tempIP;
            if(!IPAddress.TryParse(IP,out tempIP))
            {
                MessageBox.Show("IP адресс введен некорректно!");
            }
            else
            {
                Properties.Settings.Default.ip = IP;
                Properties.Settings.Default.port = Port;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
