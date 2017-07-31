using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public partial class ClientInfoForm : Form
    {
        public ClientInfoForm()
        {
            InitializeComponent();
        }

        private void ClientInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int min = 13, max = 76;
            if (checkBox1.Checked)
                groupBox1.Height = max;
            else
                groupBox1.Height = min;
        }
    }
}
