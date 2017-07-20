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
using System.IO;
using System.Security.Cryptography;

namespace MonitorCLServer
{
    public partial class MainForm : Form
    {
        bool isDedug = true;

        bool canClose = false;
        
        static Thread listenThread;

        public MainForm()
        {
            InitializeComponent();

            //db.Database.Delete();
            //db.Database.Create();

            menuStrip1.Visible = false;
            splitContainer1.Visible = false;
            timer1.Stop();
        }
        
        private void MainForm2_Load(object sender, EventArgs e)
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
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  if (ServerObject.tcpListener != null && ServerObject.tcpListener.Active)
            {
                MessageBox.Show("Сервер уже запущен!");
                return;
            }
            server = new ServerObject();
            server.setReceiveOut(Receive);
            server.setConnectIpAndPort(Settings.Default.ip, Settings.Default.port);
            listenThread = new Thread(new ThreadStart(server.Listen));
            listenThread.Start();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void MainForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
               // server.Disconnect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.notifyIcon1.Visible = false;
            }
        }

        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose)
                //if (ServerObject.tcpListener != null && ServerObject.tcpListener.Active)
                {
                    if (MessageBox.Show("Завершить работу сервера?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        canClose = false;
                    }
                }
            e.Cancel = !canClose;

            this.Visible = false;
            //this.ShowInTaskbar = false;
            this.notifyIcon1.Visible = true;

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
            //server.Disconnect();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* if (ServerObject.tcpListener != null && ServerObject.tcpListener.Active)
                server.Disconnect();
            server = new ServerObject();
            server.setReceiveOut(Receive);
            server.setConnectIpAndPort(Settings.Default.ip, Settings.Default.port);
            listenThread = new Thread(new ThreadStart(server.Listen));
            listenThread.Start();*/
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
            //UserAccount userAccount = new UserAccount();
           // List<UserAccount> list = userAccount.GetData();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
           
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            //this.ShowInTaskbar = true;
            this.notifyIcon1.Visible = false;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void выключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Выключить компьютер клиента?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //server.SendCommad("shutdown");
            }
        }

        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Перезапустить компьютер клиента?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //server.SendCommad("reboot");
            }
        }

        private void выйтиИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Выйти из системы на клиенте?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //server.SendCommad("logoff");
            }
        }

        private void подключитсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //server.SendCommad("teamviewer");
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            form.ShowDialog();
        }

        private void показатьПодробнуюИнформациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientSettingForm form = new ClientSettingForm();
            form.ShowDialog();
        }

        private void productsForm1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void settingServerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void operationSystemControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
