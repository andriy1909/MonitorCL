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
        /// <summary>
        /// 0-OK.
        /// 1-not connection.
        /// 2-login exist.
        /// </summary>
        public int errorCode = 1;

        public ProgressForm()
        {
            InitializeComponent();
        }
    }
}
