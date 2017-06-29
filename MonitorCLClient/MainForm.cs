using MonitorCLClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class MainForm : Form
    {
        ClientWork client = new ClientWork();

        public MainForm()
        {
            InitializeComponent();
        }
        
        public void Receive(string message)
        {
            richTextBox1.BeginInvoke((MethodInvoker)(() => this.richTextBox1.AppendText(message + "\n")));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            client.setReceiveOut(Receive);
            client.Connect(Settings.Default.ip, Settings.Default.port, Settings.Default.id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.SendMessage(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
         //   client.Disconnect();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.setReceiveOut(Receive);
            client.Connect(Settings.Default.ip, Settings.Default.port, Settings.Default.id);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }
    }
}
