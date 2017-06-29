using MonitorCLServer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public partial class MainForm : Form
    {
        static ServerObject server;
        static Thread listenThread;

        public MainForm()
        {
            InitializeComponent();
        }

        public void Receive(string message)
        {
            richTextBox1.BeginInvoke((MethodInvoker)(() => this.richTextBox1.AppendText(message + "\n")));
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerObject.tcpListener != null && ServerObject.tcpListener.Active)
            {
                MessageBox.Show("Сервер уже запущен!");
                return;
            }
            server = new ServerObject();
            server.setReceiveOut(Receive);
            server.setConnectIpAndPort(Settings.Default.ip, Settings.Default.port);
            listenThread = new Thread(new ThreadStart(server.Listen));
            listenThread.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ServerObject.tcpListener == null)
            {
                pictureBox1.Image = imgsStatus.Images[2];
                return;
            }
            if (ServerObject.tcpListener.Active)
            {
                pictureBox1.Image = imgsStatus.Images[1];
            }
            else
            {
                pictureBox1.Image = imgsStatus.Images[2];
            }
            if (dataGridView1.RowCount != server.clients.Count)
            {
                dataGridView1.Rows.Clear();
                foreach (var item in server.clients)
                {
                    dataGridView1.Rows.Add(new object[] { imgsStatus.Images[1], item.Id });
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                server.Disconnect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount>0)
            {
                server.BroadcastMessage(textBox1.Text, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            server = new ServerObject();
            server.setReceiveOut(Receive);
            server.setConnectIpAndPort(Settings.Default.ip, Settings.Default.port);
            listenThread = new Thread(new ThreadStart(server.Listen));
            listenThread.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
             server.Disconnect();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerObject.tcpListener != null && ServerObject.tcpListener.Active)
                server.Disconnect();
            server = new ServerObject();
            server.setReceiveOut(Receive);
            server.setConnectIpAndPort(Settings.Default.ip, Settings.Default.port);
            listenThread = new Thread(new ThreadStart(server.Listen));
            listenThread.Start();
        }
    }
}
