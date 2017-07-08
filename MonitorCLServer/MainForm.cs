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
using MonitorCLClassLibrary;

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
            if (dataGridView1.RowCount > 0)
            {
                //   server.BroadcastMessage(textBox1.Text, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            toolStripButton4.Visible = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton4.Visible = false;
            splitContainer1.Panel1Collapsed = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount();
            List<UserAccount> list = userAccount.GetData();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            if (treeView1.SelectedNode != null)
                switch (treeView1.SelectedNode.Name)
                {
                    /* case "tnUsers":
                         UserAccount userAccount = new UserAccount();
                         List<UserAccount> list = userAccount.GetData();
                         var bindingList = new BindingList<UserAccount>(list);
                         var source = new BindingSource(bindingList, null);

                         string[] fields = userAccount.GetFields().Split(';');
                         string[] desc = userAccount.GetDescriptionFields().Split(';');
                         for (int i = 0; i < fields.Length; i++)
                         {
                             dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                             {
                                 DataPropertyName = fields[i],
                                 HeaderText = desc[i]
                             });
                         }
                         foreach (var item in list)
                         {
                             dataGridView2.Rows.Add(new object[]
                             {
                                       item.AccountType,
                                       item.Caption,
                                       item.Description,
                                       item.Disabled,
                                       item.Domain,
                                       item.FullName,
                                       item.InstallDate,
                                       item.LocalAccount,
                                       item.Lockout,
                                       item.Name,
                                       item.PasswordChangeable,
                                       item.PasswordExpires,
                                       item.PasswordRequired,
                                       item.SID,
                                       item.SIDType,
                                       item.Status
                             });
                         }

                         //  dataGridView2.DataSource = list;
                         break;*/
                    case "tnOS":
                        OperatingSystemScan os = new OperatingSystemScan();
                        os.GetData();
                        string[] fields = os.Fields.Split(';');

                        dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "fname",
                            HeaderText = "name"
                        });

                        dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "fvalue",
                            HeaderText = "value"
                        });

                        foreach (var item in fields)
                        {
                            dataGridView2.Rows.Add(new object[]
                            {
                                      item,
                                      os[item]
                            });
                        }
                        break;
                    default:
                        break;
                }
        }        
    }
}
