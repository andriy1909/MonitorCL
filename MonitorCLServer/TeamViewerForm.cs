using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public partial class TeamViewerForm : Form
    {
        public TeamViewerForm()
        {
            InitializeComponent();
        }

        private void TeamViewerForm_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("TeamViewer.exe").Count() == 0)
            {
                Process.Start(Application.StartupPath + "\\teamviewer.exe");
                Thread.Sleep(7000);

                var BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics GH = Graphics.FromImage(BM as Image);
                GH.CopyFromScreen(0, 0, 0, 0, BM.Size);

                pictureBox1.Image = BM;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GH = Graphics.FromImage(BM as Image);
            GH.CopyFromScreen(0, 0, 0, 0, BM.Size);

            pictureBox1.Image = BM;
        }
    }
}
