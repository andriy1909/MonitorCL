using MonitorCLClassLibrary;
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
    public partial class ProgressForm : Form
    {
        ClientWork client;
        /// <summary>
        /// 0-OK.
        /// 1-not connection.
        /// 2-login exist.
        /// 3-error.
        /// </summary>
        public int errorCode = 1;

        public ProgressForm(ClientWork client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            client.Connect();
        }
    }
}
