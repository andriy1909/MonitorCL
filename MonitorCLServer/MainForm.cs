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
using System.IO;
using System.Security.Cryptography;

namespace MonitorCLServer
{
    public partial class MainForm : Form
    {
        bool isDedug = true;

        bool canClose = false;
        DataContext db = new DataContext();

        static ServerObject server;
        static Thread listenThread;

        public MainForm()
        {
            InitializeComponent();

            db.Database.Delete();
            db.Database.Create();

            menuStrip1.Visible = false;
            splitContainer1.Visible = false;
            timer1.Stop();
        }

        public void Receive(string message)
        {
            //richTextBox1.BeginInvoke((MethodInvoker)(() => this.richTextBox1.AppendText(message + "\n")));
            if (MessageBox.Show("Разрешить пользователю " + message + " зарегистрироватся?", "Попытка подключения", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                server.RemoveConnection(message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Show();
            if (isDedug || new LoginForm().ShowDialog() == DialogResult.OK)
            {
                menuStrip1.Visible = true;
                splitContainer1.Visible = true;
                this.ContextMenuStrip = null;
            }
            else
            {
                return;
            }

            server = new ServerObject();
            server.setReceiveOut(Receive);
            server.setConnectIpAndPort(Settings.Default.ip, Settings.Default.port);
            listenThread = new Thread(new ThreadStart(server.Listen));
            listenThread.Start();
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
            if (tvClients.Nodes.Count != server.clients.Count)
            {
                tvClients.Nodes.Clear();
                foreach (var item in server.clients)
                {
                    tvClients.Nodes.Add(item.login);
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose)
                if (ServerObject.tcpListener != null && ServerObject.tcpListener.Active)
                {
                    if (MessageBox.Show("Завершить работу сервера?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        canClose = false;
                    }
                }
            e.Cancel = !canClose;
            
            //    this.ShowInTaskbar = false;
            //this.notifyIcon1.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  if (dataGridView1.RowCount > 0)
            {
                //   server.BroadcastMessage(textBox1.Text, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
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
            {
                string[] fields;
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
                        fields = os.Fields.Split(';');

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
                    case "tnPrograms":
                        Product product = new Product();
                        List<Product> list = product.GetData();

                        fields = product.Fields.Split(';');
                        string[] desc = product.Fields.Split(';');
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
                                       item.Name,
                                       item.IdentifyingNumber,
                                       (item.InstallDate.TimeOfDay==DateTime.MinValue.TimeOfDay)?item.InstallDate.ToShortDateString():item.InstallDate.ToString(),//.ToShortDateString()+ " " +item.InstallDate.ToShortTimeString(),
                                       item.InstallLocation,
                                       item.Vendor,
                                       item.Version
                            });
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void tvClients_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvClients_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void tvClients_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tvClients.PointToClient(new Point(e.X, e.Y));

            tvClients.SelectedNode = tvClients.GetNodeAt(targetPoint);
        }

        private void tvClients_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = tvClients.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = tvClients.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                targetNode.Expand();
            }
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            return ContainsNode(node1, node2.Parent);
        }

        private void tvClients_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel1.Visible = e.Node != null;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new LoginForm().ShowDialog() == DialogResult.OK)
            {
                menuStrip1.Visible = true;
                splitContainer1.Visible = true;
                this.ContextMenuStrip = null;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            canClose = true;
            Application.Exit();
        }

    }
}
