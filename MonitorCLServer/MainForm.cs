using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MonitorCLClassLibrary.Model;
using System.Linq;
using MonitorCLClassLibrary.Server;
using MonitorCLServer.Properties;

namespace MonitorCLServer
{
    public partial class MainForm : Form
    {
        bool isDedug = true;

        bool canClose = false;

        //static Thread listenThread;

        public MainForm()
        {
            InitializeComponent();

           // MonitoringDB.ReCreareDB();

            menuStrip1.Visible = false;
            splitContainer1.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

            //зазрузка списку клієнтів
            UpdateUsersList();
                                    
            ServerObject server = new ServerObject();
            server.StartListener(Settings.Default.ip, Settings.Default.port);

            this.Show();
            /*


            for (int i = 0; i < 4; i++)
            {
                Bitmap bm = new Bitmap(32, 16);
                Bitmap bm1;
                if (i == 2)
                    bm1 = new Bitmap(imageList1.Images[6]);
                else
                    bm1 = new Bitmap(imageList1.Images[5]);
                Bitmap bm2 = new Bitmap(imageList1.Images[i]);

                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(bm1, 0, 0, 16, 16);
                g.DrawImage(bm2, 16, 0, 16, 16);
                g.Dispose();
                imageList2.Images[i] = bm;
            }*/
        }

        public void UpdateUsersList()
        {
            TreeNode selectNode = tvClients.SelectedNode;
            tvClients.Nodes.Clear();
            var groupList = MonitoringDB.GetUsersGroups().OrderBy(x => x.Level);
            foreach (var item in groupList)
            {
                TreeNode node = new TreeNode()
                {
                    Name = "gr" + item.UsersGroupId.ToString(),
                    Text = item.Name,
                    ImageIndex = 0,
                    ToolTipText = item.Information,
                    Tag = item
                };
                if (item.Level > 0)
                {
                    TreeNode parentNode = tvClients.Nodes.Find("gr" + item.Parent.UsersGroupId, true).First();
                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        tvClients.Nodes.Add(node);
                    }
                }
                else
                {
                    tvClients.Nodes.Add(node);
                }
            }

            var userList = MonitoringDB.GetUsers();
            foreach (var item in userList)
            {
                TreeNode node = new TreeNode()
                {
                    Name = "u" + item.UserId.ToString(),
                    Text = item.Name,
                    ImageIndex = item.TypePC,
                    SelectedImageIndex = item.TypePC,
                    ToolTipText = item.UserName + " " + item.Phone,
                    Tag = item
                };

                if (item.Group == null)
                {
                    tvClients.Nodes.Add(node);
                }
                else
                {
                    TreeNode parentNode = tvClients.Nodes.Find("gr" + item.Group.UsersGroupId, true).First();
                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        tvClients.Nodes.Add(node);
                    }
                }
            }

            tvClients.SelectedNode = selectNode;
        }

        private void tsbAddGroup_Click(object sender, EventArgs e)
        {
            AddGroupForm addForm = new AddGroupForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                UpdateUsersList();
            }
        }

        private void tsbAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm();
            form.ShowDialog();
            UpdateUsersList();
        }

        private void tsbRefreshUserList_Click(object sender, EventArgs e)
        {
            UpdateUsersList();
        }

        private void tsmiAddGroup_Click(object sender, EventArgs e)
        {
            AddGroupForm addForm = new AddGroupForm(tvClients.SelectedNode);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                UpdateUsersList();
            }
        }

        private void tsmiAddUser_Click(object sender, EventArgs e)
        {
            var node = tvClients.SelectedNode;
            if (node != null && node.Name.Contains("u"))
                node = node.Parent;
            AddUserForm addForm = new AddUserForm(node);
            addForm.ShowDialog();
            UpdateUsersList();
        }

        private void tsbDeleteUserListItem_Click(object sender, EventArgs e)
        {
            if (tvClients.SelectedNode == null)
                return;



            switch (tvClients.SelectedNode.Tag.GetType().Name)
            {
                case "User":
                    if (MessageBox.Show("Удалить " + tvClients.SelectedNode.Text + "?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    if (!User.Delete(int.Parse(tvClients.SelectedNode.Name.Remove(0, 2))))
                        MessageBox.Show("Ошибка удаления!");
                    break;
                case "UsersGroup":
                    if (tvClients.SelectedNode.Nodes.Count == 0)
                    {
                        if (MessageBox.Show("Удалить группу " + tvClients.SelectedNode.Text + "?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        if (!UsersGroup.Delete(int.Parse(tvClients.SelectedNode.Name.Remove(0, 2))))
                            MessageBox.Show("Ошибка удаления!");
                    }
                    else
                    {
                        if (MessageBox.Show("Группа не пустая, удаление невозможно!", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //if (!UsersGroup.Delete(int.Parse(tvClients.SelectedNode.Name.Remove(0, 2))))
                            //    MessageBox.Show("Ошибка удаления!");
                            return;
                        }
                    }
                    break;
            }
            UpdateUsersList();
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

        //!!
        private void tvClients_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = tvClients.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = tvClients.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (targetNode.Tag.GetType().Name == "UsersGroup")
            {
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        draggedNode.Remove();
                        switch (draggedNode.Tag.GetType().Name)
                        {
                            case "User":
                                User user = ((User)draggedNode.Tag);
                                if (user != null)
                                {
                                    user.Group = ((UsersGroup)targetNode.Tag);
                                    //user.Edit();
                                }
                                break;
                            case "UsersGroup":

                                break;
                        }
                        targetNode.Nodes.Add(draggedNode);
                    }
                     
                    targetNode.Expand();
                }
            }
            else
            {
                MessageBox.Show("Добавление возможно только в группу!");
            }
        }
        
        private void показатьПодробнуюИнформациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = tvClients.SelectedNode;
            if (node == null)
                return;
            if (node.Tag.GetType() == typeof(User))
            {
                AddUserForm form = new AddUserForm((User)node.Tag);
                form.Show();
            }
        }

        #region NoCheck


        //-
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

        //-
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

        //-
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

        //-
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  if (dataGridView1.RowCount > 0)
            {
                //   server.BroadcastMessage(textBox1.Text, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        //-
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //server.Disconnect();
        }

        //-
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

        //-
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
           // toolStripButton4.Visible = true;
        }

        //-
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
       //     toolStripButton4.Visible = false;
            splitContainer1.Panel1Collapsed = false;
        }

        //-
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UserAccount userAccount = new UserAccount();
            // List<UserAccount> list = userAccount.GetData();
        }

        //-
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            return ContainsNode(node1, node2.Parent);
        }
        
        //-
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new LoginForm().ShowDialog() == DialogResult.OK)
            {
                menuStrip1.Visible = true;
                splitContainer1.Visible = true;
                this.ContextMenuStrip = null;
            }
        }

        //-
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            canClose = true;
            Application.Exit();
        }

        //-
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            //this.ShowInTaskbar = true;
            this.notifyIcon1.Visible = false;
        }

        //-
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {/*
            dataGridView1.Rows.Clear();
            lbText.Text = e.Node.Text;
            switch (e.Node.Name)
            {
                case "tnOS":
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(new OperationSystemControl());
                    break;
                case "tnPrograms":
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(new ProductsControl());
                    break;
                case "tnau":
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(new ProductsControl("au"));
                    break;
                case "tnCPU":
                    #region MyRegion
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(panel3);

                    dataGridView1.Rows.Add(new object[] { "", "AddressWidth", "64" });
                    dataGridView1.Rows.Add(new object[] { "", "Architecture", "9" });
                    dataGridView1.Rows.Add(new object[] { "", "Availability", "3" });
                    dataGridView1.Rows.Add(new object[] { "", "Caption", "Intel64 Family 6 Model 23 Stepping 10" });
                    dataGridView1.Rows.Add(new object[] { "", "ConfigManagerErrorCode", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ConfigManagerUserConfig", "" });
                    dataGridView1.Rows.Add(new object[] { "", "CpuStatus", "1" });
                    dataGridView1.Rows.Add(new object[] { "", "CreationClassName", "Win32_Processor" });
                    dataGridView1.Rows.Add(new object[] { "", "CurrentClockSpeed", "2992" });
                    dataGridView1.Rows.Add(new object[] { "", "CurrentVoltage", "13" });
                    dataGridView1.Rows.Add(new object[] { "", "DataWidth", "64" });
                    dataGridView1.Rows.Add(new object[] { "", "Description", "Intel64 Family 6 Model 23 Stepping 10" });
                    dataGridView1.Rows.Add(new object[] { "", "DeviceID", "CPU0" });
                    dataGridView1.Rows.Add(new object[] { "", "ErrorCleared", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ErrorDescription", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ExtClock", "1333" });
                    dataGridView1.Rows.Add(new object[] { "", "Family", "191" });
                    dataGridView1.Rows.Add(new object[] { "", "InstallDate", "" });
                    dataGridView1.Rows.Add(new object[] { "", "L2CacheSize", "6144" });
                    dataGridView1.Rows.Add(new object[] { "", "L2CacheSpeed", "" });
                    dataGridView1.Rows.Add(new object[] { "", "L3CacheSize", "0" });
                    dataGridView1.Rows.Add(new object[] { "", "L3CacheSpeed", "0" });
                    dataGridView1.Rows.Add(new object[] { "", "LastErrorCode", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Level", "6" });
                    dataGridView1.Rows.Add(new object[] { "", "LoadPercentage", "0" });
                    dataGridView1.Rows.Add(new object[] { "", "Manufacturer", "GenuineIntel" });
                    dataGridView1.Rows.Add(new object[] { "", "MaxClockSpeed", "2992" });
                    dataGridView1.Rows.Add(new object[] { "", "Name", "Intel(R) Core(TM)2 Duo CPU     E8400  @ 3.00GHz" });
                    dataGridView1.Rows.Add(new object[] { "", "NumberOfCores", "2" });
                    dataGridView1.Rows.Add(new object[] { "", "NumberOfLogicalProcessors", "2" });
                    dataGridView1.Rows.Add(new object[] { "", "OtherFamilyDescription", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PNPDeviceID", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PowerManagementCapabilities[]", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PowerManagementSupported", "False" });
                    dataGridView1.Rows.Add(new object[] { "", "ProcessorId", "BFEBFBFF0001067A" });
                    dataGridView1.Rows.Add(new object[] { "", "ProcessorType", "3" });
                    dataGridView1.Rows.Add(new object[] { "", "Revision", "5898" });
                    dataGridView1.Rows.Add(new object[] { "", "Role", "CPU" });
                    dataGridView1.Rows.Add(new object[] { "", "SocketDesignation", "CPU" });
                    dataGridView1.Rows.Add(new object[] { "", "Status", "OK" });
                    dataGridView1.Rows.Add(new object[] { "", "StatusInfo", "3" });
                    dataGridView1.Rows.Add(new object[] { "", "Stepping", "" });
                    dataGridView1.Rows.Add(new object[] { "", "SystemCreationClassName", "Win32_ComputerSystem" });
                    dataGridView1.Rows.Add(new object[] { "", "SystemName", "DELL-CORE2-01" });
                    dataGridView1.Rows.Add(new object[] { "", "UniqueId", "" });
                    dataGridView1.Rows.Add(new object[] { "", "UpgradeMethod", "21" });
                    dataGridView1.Rows.Add(new object[] { "", "Version", "" });
                    dataGridView1.Rows.Add(new object[] { "", "VoltageCaps", "" });
                    #endregion
                    break;
                case "tnBattery":
                    #region MyRegion
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(panel3);

                    dataGridView1.Rows.Add(new object[] { "", "Availability", "2" });
                    dataGridView1.Rows.Add(new object[] { "", "BatteryRechargeTime", "" });
                    dataGridView1.Rows.Add(new object[] { "", "BatteryStatus", "2" });
                    dataGridView1.Rows.Add(new object[] { "", "Caption", "Internal Battery" });
                    dataGridView1.Rows.Add(new object[] { "", "Chemistry", "6" });
                    dataGridView1.Rows.Add(new object[] { "", "ConfigManagerErrorCode", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ConfigManagerUserConfig", "" });
                    dataGridView1.Rows.Add(new object[] { "", "CreationClassName", "Win32_Battery" });
                    dataGridView1.Rows.Add(new object[] { "", "Description", "Internal Battery" });
                    dataGridView1.Rows.Add(new object[] { "", "DesignCapacity", "" });
                    dataGridView1.Rows.Add(new object[] { "", "DesignVoltage", "12343" });
                    dataGridView1.Rows.Add(new object[] { "", "DeviceID", "25591LGC42T4850" });
                    dataGridView1.Rows.Add(new object[] { "", "ErrorCleared", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ErrorDescription", "" });
                    dataGridView1.Rows.Add(new object[] { "", "EstimatedChargeRemaining", "100" });
                    dataGridView1.Rows.Add(new object[] { "", "EstimatedRunTime", "71582788" });
                    dataGridView1.Rows.Add(new object[] { "", "ExpectedBatteryLife", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ExpectedLife", "" });
                    dataGridView1.Rows.Add(new object[] { "", "FullChargeCapacity", "" });
                    dataGridView1.Rows.Add(new object[] { "", "InstallDate", "" });
                    dataGridView1.Rows.Add(new object[] { "", "LastErrorCode", "" });
                    dataGridView1.Rows.Add(new object[] { "", "MaxRechargeTime", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Name", "42T4850" });
                    dataGridView1.Rows.Add(new object[] { "", "PNPDeviceID", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PowerManagementCapabilities[]", "| 1" });
                    dataGridView1.Rows.Add(new object[] { "", "PowerManagementSupported", "false" });
                    dataGridView1.Rows.Add(new object[] { "", "SmartBatteryVersion", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Status", "OK" });
                    dataGridView1.Rows.Add(new object[] { "", "StatusInfo", "" });
                    dataGridView1.Rows.Add(new object[] { "", "SystemCreationClassName", "Win32_ComputerSystem" });
                    dataGridView1.Rows.Add(new object[] { "", "SystemName", "USER-THINK" });
                    dataGridView1.Rows.Add(new object[] { "", "TimeOnBattery", "" });
                    dataGridView1.Rows.Add(new object[] { "", "TimeToFullCharge", "" });
                    #endregion
                    break;
                case "tnMotheboad":
                    #region MyRegion
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(panel3);

                    dataGridView1.Rows.Add(new object[] { "", "Caption", "Base Board" });
                    dataGridView1.Rows.Add(new object[] { "", "ConfigOptions[]", "" });
                    dataGridView1.Rows.Add(new object[] { "", "CreationClassName", "Win32_BaseBoard" });
                    dataGridView1.Rows.Add(new object[] { "", "Depth", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Description", "Base Board" });
                    dataGridView1.Rows.Add(new object[] { "", "Height", "" });
                    dataGridView1.Rows.Add(new object[] { "", "HostingBoard", "True" });
                    dataGridView1.Rows.Add(new object[] { "", "HotSwappable", "False" });
                    dataGridView1.Rows.Add(new object[] { "", "InstallDate", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Manufacturer", "Dell Inc." });
                    dataGridView1.Rows.Add(new object[] { "", "Model", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Name", "Base Board" });
                    dataGridView1.Rows.Add(new object[] { "", "OtherIdentifyingInfo", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PartNumber", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PoweredOn", "True" });
                    dataGridView1.Rows.Add(new object[] { "", "Product", "0DFRFW" });
                    dataGridView1.Rows.Add(new object[] { "", "Removable", "True" });
                    dataGridView1.Rows.Add(new object[] { "", "Replaceable", "False" });
                    dataGridView1.Rows.Add(new object[] { "", "RequirementsDescription", "" });
                    dataGridView1.Rows.Add(new object[] { "", "RequiresDaughterBoard", "False" });
                    dataGridView1.Rows.Add(new object[] { "", "SerialNumber", "..CN7360404S00SB." });
                    dataGridView1.Rows.Add(new object[] { "", "SKU", "" });
                    dataGridView1.Rows.Add(new object[] { "", "SlotLayout", "" });
                    dataGridView1.Rows.Add(new object[] { "", "SpecialRequirements", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Status", "OK" });
                    dataGridView1.Rows.Add(new object[] { "", "Tag", "Base Board" });
                    dataGridView1.Rows.Add(new object[] { "", "Version", "A01" });
                    dataGridView1.Rows.Add(new object[] { "", "Weight", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Width", "" });

                    #endregion
                    break;
                case "tnBios":
                    #region MyRegion
                    pnContents.Controls.Clear();
                    pnContents.Controls.Add(panel3);

                    dataGridView1.Rows.Add(new object[] { "", "BiosCharacteristics[]", "| 7 | 9 | 10 | 11 | 12 | 14 | 15 | 16 | 19 | 21 | 24 | 26 | 27 | 28 | 29 | 32 | 33 | 40 | 41 | 42 | 48 | 49 | 64 | 65 | 66 | 67 | 68 | 69 | 70 | 71 | 72 | 73 | 74 | 75 | 76 | 77 | 78 | 79" });
                    dataGridView1.Rows.Add(new object[] { "", "BIOSVersion[]", "| DELL   - 15 | Phoenix ROM BIOS PLUS Version 1.10 A03" });
                    dataGridView1.Rows.Add(new object[] { "", "BuildNumber", "" });
                    dataGridView1.Rows.Add(new object[] { "", "Caption", "Phoenix ROM BIOS PLUS Version 1.10 A03" });
                    dataGridView1.Rows.Add(new object[] { "", "CodeSet", "" });
                    dataGridView1.Rows.Add(new object[] { "", "CurrentLanguage", "en|US|iso8859-1" });
                    dataGridView1.Rows.Add(new object[] { "", "Description", "Phoenix ROM BIOS PLUS Version 1.10 A03" });
                    dataGridView1.Rows.Add(new object[] { "", "IdentificationCode", "" });
                    dataGridView1.Rows.Add(new object[] { "", "InstallableLanguages", "1" });
                    dataGridView1.Rows.Add(new object[] { "", "InstallDate", "" });
                    dataGridView1.Rows.Add(new object[] { "", "LanguageEdition", "" });
                    dataGridView1.Rows.Add(new object[] { "", "ListOfLanguages[]", "| en|US|iso8859-1" });
                    dataGridView1.Rows.Add(new object[] { "", "Manufacturer", "Dell Inc." });
                    dataGridView1.Rows.Add(new object[] { "", "Name", "Phoenix ROM BIOS PLUS Version 1.10 A03" });
                    dataGridView1.Rows.Add(new object[] { "", "OtherTargetOS", "" });
                    dataGridView1.Rows.Add(new object[] { "", "PrimaryBIOS", "True" });
                    dataGridView1.Rows.Add(new object[] { "", "ReleaseDate", "20100213000000.000000+000" });
                    dataGridView1.Rows.Add(new object[] { "", "SerialNumber", "8J2PKM1" });
                    dataGridView1.Rows.Add(new object[] { "", "SMBIOSBIOSVersion", "A03" });
                    dataGridView1.Rows.Add(new object[] { "", "SMBIOSMajorVersion", "2" });
                    dataGridView1.Rows.Add(new object[] { "", "SMBIOSMinorVersion", "5" });
                    dataGridView1.Rows.Add(new object[] { "", "SMBIOSPresent", "True" });
                    dataGridView1.Rows.Add(new object[] { "", "SoftwareElementID", "Phoenix ROM BIOS PLUS Version 1.10 A03" });
                    dataGridView1.Rows.Add(new object[] { "", "SoftwareElementState", "3" });
                    dataGridView1.Rows.Add(new object[] { "", "Status", "OK" });
                    dataGridView1.Rows.Add(new object[] { "", "TargetOperatingSystem", "0" });
                    dataGridView1.Rows.Add(new object[] { "", "Version", "DELL   - 15" });

                    #endregion
                    break;
                default:
                    break;
            }*/
        }

        //-
        private void выключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Выключить компьютер клиента?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //server.SendCommad("shutdown");
            }
        }

        //-
        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Перезапустить компьютер клиента?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //server.SendCommad("reboot");
            }
        }

        //-
        private void выйтиИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Выйти из системы на клиенте?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //server.SendCommad("logoff");
            }
        }

        //-
        private void подключитсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //server.SendCommad("teamviewer");
            TeamViewerForm form = new TeamViewerForm();
            form.Show();
        }

        //-
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            form.Show();
        }
        
        //-
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            OpenViewForm form = new OpenViewForm();
            form.Show();
        }

        //-
        private void tvClients_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ExpandAll();
        }

        //-
        private void treeView2_Layout(object sender, LayoutEventArgs e)
        {
            treeView2.ExpandAll();
        }

        //-
        private void переназватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvClients.SelectedNode != null)
                tvClients.SelectedNode.BeginEdit();
        }

        //-
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            //pnContents.Controls.Clear();
            //pnContents.Controls.Add(panel3);

            dataGridView1.Rows.Add(new object[] { "", "Компьютер", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Операционная система", "Microsoft Windows 7 Professional" });
            dataGridView1.Rows.Add(new object[] { "", "Пакет обновления ОС", "Service Pack 1" });
            dataGridView1.Rows.Add(new object[] { "", "Имя компьютера", "DELL-CORE2-01" });
            dataGridView1.Rows.Add(new object[] { "", "Имя пользователя", "Dell" });
            dataGridView1.Rows.Add(new object[] { "", "Домен", "WORKGROUP" });
            dataGridView1.Rows.Add(new object[] { "", "Дата / Время", "24.07.17 13:20" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Системная плата", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Тип ЦП", "DualCore Intel Core 2 Duo E8400, 3000 MHz(9 x 333)" });
            dataGridView1.Rows.Add(new object[] { "", "Системная плата", "Dell OptiPlex 780" });
            dataGridView1.Rows.Add(new object[] { "", "Чипсет системной платы", "Intel Eaglelake Q45" });
            dataGridView1.Rows.Add(new object[] { "", "Системная память", "" });
            dataGridView1.Rows.Add(new object[] { "", "DIMM1: Nanya NT2GC64B8HC0NF-CG", "2 ГБ DDR3-1333 DDR3 SDRAM" });
            dataGridView1.Rows.Add(new object[] { "", "Тип BIOS", "Phoenix(02/13/10)" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Отображение", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Видеоадаптер", "Intel(R) Q45/Q43 Express Chipset(1783608 КБ)" });
            dataGridView1.Rows.Add(new object[] { "", "Монитор", "Samsung SyncMaster 177N/710N/MagicSyncMaster CX701N/CX711N[17\" LCD]  (HVGY9103610)" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Мультимедиа", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Звуковой адаптер", "Analog Devices AD1984A @ Intel 82801JB ICH10 - High Definition Audio Controller[B - 0]" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Хранение данных", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "IDE-контроллер", "Intel(R) ICH10D / DO SATA AHCI Controller" });
            dataGridView1.Rows.Add(new object[] { "", "IDE-контроллер", "Стандартный двухканальный контроллер PCI IDE" });
            dataGridView1.Rows.Add(new object[] { "", "Дисковый накопитель", "ADATA USB Flash Drive USB Device(14 ГБ, USB)" });
            dataGridView1.Rows.Add(new object[] { "", "Дисковый накопитель", "ATA Hitachi HTS72501 SCSI Disk Device(149 ГБ)" });
            dataGridView1.Rows.Add(new object[] { "", "Дисковый накопитель", "ATA KINGSTON SKC300F SCSI Disk Device(55 ГБ)" });
            dataGridView1.Rows.Add(new object[] { "", "SMART-статус жёстких дисков", "OK" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Разделы", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "C: (NTFS)", "49.0 ГБ(12.8 ГБ свободно)" });
            dataGridView1.Rows.Add(new object[] { "", "D: (NTFS)", "25, 6 ГБ(2437 МБ свободно)" });
            dataGridView1.Rows.Add(new object[] { "", "E: (NTFS)", "149.0 ГБ(42.8 ГБ свободно)" });
            dataGridView1.Rows.Add(new object[] { "", "Общий объём", "225.0 ГБ(68, 4 ГБ свободно)" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Ввод", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Клавиатура", "Клавиатура HID" });
            dataGridView1.Rows.Add(new object[] { "", "Мышь", "HID - совместимая мышь" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Сеть", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Первичный адрес IP", "192.168.1.118" });
            dataGridView1.Rows.Add(new object[] { "", "Первичный МАС-адрес", " 255.255.255.0" });
            dataGridView1.Rows.Add(new object[] { "", "Первичный адрес MAC", "B8 - AC - 6F - A0 - 2A - E4" });
            dataGridView1.Rows.Add(new object[] { "", "Сетевой адаптер", "Intel(R) 82567LM - 3 Gigabit Network Connection(192. [TRIAL VERSION])" });
            dataGridView1.Rows.Add(new object[] { "", "Сетевой адаптер", "VirtualBox Host - Only Ethernet Adapter(192. [TRIAL VERSION])" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Периферийные устройства", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Принтер", "Fax" });
            dataGridView1.Rows.Add(new object[] { "", "Принтер", "Microsoft XPS Document Writer" });
            dataGridView1.Rows.Add(new object[] { "", "USB-устройство", "Запоминающее устройство для USB" });
            dataGridView1.Rows.Add(new object[] { "", "", "" });
            dataGridView1.Rows.Add(new object[] { "", "Проблемы и советы", "" });
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Rows.Add(new object[] { "", "Проблема", "На диске C: свободно лишь 3 %." });
            dataGridView1.Rows.Add(new object[] { "", "Проблема", "На диске D: свободно лишь 10 %." });
        }


        #endregion

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }

    #region Classes

#pragma warning disable CS0169
#pragma warning disable CS0649
    //-
    class Win32_BIOS
    {
        /// <summary>
        /// Виробник.
        /// </summary>
        string Manufacturer;
        /// <summary>
        /// Назва, використовується для ідентифікації цього елемента програмного забезпечення.
        /// </summary>
        string Name;
        /// <summary>
        /// Дата випуску BIOS Windows у форматі координатного універсального часу (UTC)
        /// </summary>
        DateTime ReleaseDate;
        /// <summary>
        /// Призначений серійний номер елемента програмного забезпечення.
        /// </summary>
        string SerialNumber;
        /// <summary>
        /// Поточний стан.
        /// </summary>
        /*
OK ("OK")
Error ("Error")
Degraded ("Degraded")
Unknown ("Unknown")
Pred Fail ("Pred Fail")
Starting ("Starting")
Stopping ("Stopping")
Service ("Service")
Stressed ("Stressed")
NonRecover ("NonRecover")
No Contact ("No Contact")
Lost Comm ("Lost Comm")*/
        /*
         ОК ("ОК")
        Помилка ("Помилка")
        Деградований ("деградований")
        Невідомо ("Невідомо")
        Pred Fail ("Pred Fail")
        Початок ("Початок")
        Зупинка ("Зупинка")
        Сервіс ("Сервіс")
        Підкреслений ("підкреслив")
        NonRecover ("NonRecover")
        Немає контактів ("Немає контактів")
        Lost Comm ("Lost Comm")*/
        string Status;
        /// <summary>
        /// Версія BIOS. Цей рядок створено виробником BIOS.
        /// </summary>
        string Version;
    }

    //-
    class Win32_BootConfiguration
    {
        /// <summary>
        /// Короткий текстовий опис поточного об'єкта.
        /// </summary>
        string Caption;
        /// <summary>
        /// Текстовий опис поточного об'єкта.
        /// </summary>
        string Description;
        /// <summary>
        /// Шлях до системних файлів, необхідних для завантаження системи.
        /// </summary>
        string BootDirectory;
        /// <summary>
        /// Шлях до файлів конфігурації. 
        /// </summary>
        string ConfigurationPath;
        /// <summary>
        /// Останній символ диска, до якого присвоєно фізичний диск.
        /// Приклад: "E:"
        /// </summary>
        string LastDrive;
        /// <summary>
        /// Ім'я конфігурації завантаження. Це ідентифікатор для конфігурації завантаження.
        /// </summary>
        string Name;
        /// <summary>
        /// Каталог, де можна зберігати тимчасові файли під час завантаження.
        /// </summary>
        string ScratchDirectory;
        /// <summary>
        /// Каталог, де зберігаються тимчасові файли.
        /// Приклад: "C:\TEMP"
        /// </summary>
        string TempDirectory;
    }

    //-
    /// <summary>
    ///  класс WMI представляет собой общие устройства адаптера , встроенные в материнскую плату (системной плате).
    /// </summary>
    class Win32_OnBoardDevice
    {
        /// <summary>
        /// Описание объекта.
        /// </summary>
        string Description;
        /// <summary>
        /// Тип представляемого устройства.
        /// 
        /// Другое (1)
        /// Неизвестно(2)
        /// Видео(3)
        /// Контроллер SCSI(4)
        /// Ethernet(5)
        /// Кольцо Token(6)
        /// Звук(7)
        /// </summary>
        ushort DeviceType;
        /// <summary>
        /// Если TRUE , встроенное устройство доступно для использования.
        /// </summary>
        bool Enabled;
        /// <summary>
        /// Уникальный идентификатор встроенного устройства, подключенного к системе.
        /// </summary>
        string Tag;
    }

    //-
    class OS
    {
        /// <summary>
        /// Номер сборки операционной системы.
        /// </summary>
        public string BuildNumber;
        /// <summary>
        /// Краткое описание объекта - однострочная строка. Строка содержит версию операционной системы. Например, «Microsoft Windows 7 Enterprise». Это свойство может быть локализовано.
        /// </summary>
        public string Caption;
        /// <summary>
        /// NULL - завершена строка, которая указывает последний пакет обновления, установленный на компьютере. 
        /// Если пакет обновления не установлен, строка будет NULL .
        /// Пример: «Service Pack 3»
        /// </summary>
        public string CSDVersion;
        /// <summary>
        /// Название компьютерной системы обзора.
        /// </summary>
        public string CSName;
        /// <summary>
        /// Число, в минутах, операционная система смещена от среднего времени по Гринвичу (GMT). Число положительное, отрицательное или ноль.
        /// </summary>
        public short CurrentTimeZone;
        /// <summary>
        /// Предотвращение выполнения данных - это аппаратная функция, предотвращающая атаки переполнения буфера, прекращая выполнение кода на страницах памяти типа данных. Если True , то эта функция доступна. На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище BCD, и соответственно устанавливаются свойства в Win32_OperatingSystem .
        /// </summary>
        public bool DataExecutionPrevention_Available;
        /// <summary>
        /// Когда доступна аппаратная функция предотвращения выполнения данных, это свойство указывает, что функция настроена на работу для 32-разрядных приложений, если True . На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище данных конфигурации загрузки (BCD), а свойства в Win32_OperatingSystem установлены соответственно.
        /// </summary>
        public bool DataExecutionPrevention_32BitApplications;
        /// <summary>
        /// Когда доступна аппаратная функция предотвращения выполнения данных, это свойство указывает, что функция настроена на работу драйверов, если True . На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище BCD, и соответственно устанавливаются свойства в Win32_OperatingSystem .
        /// </summary>
        public bool DataExecutionPrevention_Drivers;
        /// <summary>
        /// Уровень шифрования для защищенных транзакций: 40-разрядный, 128-разрядный или n -бит .
        /// 
        /// 40-бит (0)
        /// 128-бит(1)
        /// N-бит(2)
        /// </summary>
        public uint EncryptionLevel;
        /// <summary>
        /// Число в килобайтах физической памяти в настоящее время не используется и доступно.
        /// </summary>
        public ulong FreePhysicalMemory;
        /// <summary>
        /// Число в килобайтах, которое может быть отображено в файлы подкачки операционной системы, не вызывая замены других страниц.
        /// </summary>
        public ulong FreeSpaceInPagingFiles;
        /// <summary>
        /// Число в килобайтах виртуальной памяти в настоящее время не используется и доступно.
        /// </summary>
        public ulong FreeVirtualMemory;
        /// <summary>
        /// Дата установки.
        /// </summary>
        public DateTime InstallDate;
        /// <summary>
        /// Дата и время последней загрузки операционной системы.
        /// </summary>
        public DateTime LastBootUpTime;
        /// <summary>
        /// Версия операционной системы локальной даты и времени суток.
        /// </summary>
        public DateTime LocalDateTime;
        /// <summary>
        /// Максимальное количество в килобайтах памяти, которое может быть выделено процессу.
        /// </summary>
        public ulong MaxProcessMemorySize;
        /// <summary>
        /// Количество сеансов пользователя, для которых операционная система хранит информацию о состоянии в настоящее время.
        /// </summary>
        public uint NumberOfUsers;
        /// <summary>
        /// Архитектура операционной системы, в отличие от процессора.
        /// </summary>
        public string OSArchitecture;
        /// <summary>
        /// Дополнительная системная информация.
        /// </summary>
        /*
        Рабочая станция (1)
        Контроллер домена (2)
        Сервер (3)
        */
        public uint ProductType;
        /// <summary>
        /// Имя зарегистрированного пользователя операционной системы.
        /// </summary>
        public string RegisteredUser;
        /// <summary>
        /// Серийный идентификационный номер продукта операционной системы.
        /// </summary>
        public string SerialNumber;
        /// <summary>
        /// Общее количество килобайт, которые могут быть сохранены в файлах подкачки операционной системы - 0 (ноль), указывает на отсутствие файлов подкачки. Имейте в виду, что это число не отражает фактический физический размер файла подкачки на диске.
        /// </summary>
        public ulong SizeStoredInPagingFiles;
        /// <summary>
        /// Текущее состояние объекта. 
        /// </summary>
        /*
        OK («OK»)
        Ошибка(«Error»)
        Деградированные(«Degraded»)
        Неизвестно(«Unknown»)
        Pred Fail(«Pred Fail»)
        Запуск(«Starting»)
        Остановка(«Stopping»)
        Сервис(«Service»)
        Подчеркнутый(«Stressed»)
        NonRecover(«NonRecover»)
        Нет контакта(«No Contact»)
        Lost Comm(«Lost Comm»)
        */
        public string Status;
        /// <summary>
        /// Буква диска, на котором находится операционная система. Пример: "C:"
        /// </summary>
        public string SystemDrive;
        /// <summary>
        /// Число в килобайтах виртуальной памяти. 
        /// </summary>
        public ulong TotalVirtualMemorySize;
        /// <summary>
        /// Общее количество в килобайтах физической памяти, доступной операционной системе.
        /// </summary>
        public ulong TotalVisibleMemorySize;
        /// <summary>
        /// Номер версии операционной системы.
        /// </summary>
        public string Version;
    }

    //-
    class Win32_Process
    {
        /// <summary>
        /// Краткое описание объекта - однострочная строка.
        /// </summary>
        string Caption;
        /// <summary>
        /// Командная строка, используемая для запуска определенного процесса, если это применимо.
        /// </summary>
        string CommandLine;
        /// <summary>
        /// Дата начала процесса.
        /// </summary>
        DateTime CreationDate;
        /// <summary>
        /// Название компьютерной системы обзора.
        /// </summary>
        string CSName;
        /// <summary>
        /// Путь к исполняемому файлу процесса.
        /// </summary>
        string ExecutablePath;
        /// <summary>
        /// Идентификатор процесса.
        /// </summary>
        string Handle;
        /// <summary>
        /// Общее количество открытых ручек, принадлежащих процессу. HandleCount - это сумма ручек, открытых в данный момент каждым потоком в этом процессе. Ручка используется для проверки или изменения системных ресурсов. Каждый дескриптор имеет запись в таблице, которая поддерживается внутри. Записи содержат адреса ресурсов и данных для идентификации типа ресурса.
        /// </summary>
        uint HandleCount;
        /// <summary>
        /// Уникальный идентификатор процесса, который создает процесс. Номера идентификаторов процессов повторно используются, поэтому они идентифицируют процесс для всего жизненного цикла этого процесса. Возможно, процесс, идентифицированный ParentProcessId , завершен, поэтому ParentProcessId может не ссылаться на текущий процесс. Также возможно, что ParentProcessId неправильно ссылается на процесс, который повторно использует идентификатор процесса. Вы можете использовать свойство CreationDate, чтобы определить, был ли указан указанный родитель, после создания процесса, представленного этим экземпляром Win32_Process .
        /// </summary>
        uint ParentProcessId;
        /// <summary>
        /// Планирование приоритета процесса в операционной системе. Чем выше значение, тем выше приоритет получает процесс. Значения приоритета могут варьироваться от 0 (ноль), что является самым низким приоритетом до 31, что является наивысшим приоритетом.
        /// </summary>
        uint Priority;
        /// <summary>
        /// Числовой идентификатор, используемый для отличия одного процесса от другого. Идентификаторы процессов действительны с момента создания процесса до завершения процесса. По завершении этот же числовой идентификатор может быть применен к новому процессу.
        /// </summary>
        uint ProcessId;
        /// <summary>
        /// Количество активных потоков в процессе. Инструкция является базовой единицей выполнения в процессоре, а поток - это объект, который выполняет инструкцию. В каждом запущенном процессе имеется по крайней мере один поток.
        /// </summary>
        uint ThreadCount;
    }

    //-
    class Win32_DiskDrive
    {
        /// <summary>
        /// Краткое описание объекта.
        /// </summary>
        string Caption;
        /// <summary>
        /// Код ошибки Configuration Manager.
        /// 
        /// Это устройство работает правильно. (0)
        ///        Устройство работает правильно.
        ///        Это устройство настроено неправильно. (1)
        ///Устройство настроено неправильно.
        ///Windows не может загрузить драйвер для этого устройства. (2)
        ///Драйвер для этого устройства может быть поврежден, или ваша система может работать с низким объемом памяти или другими ресурсами. (3)
        ///Драйвер для этого устройства может быть поврежден или система может быть низкой в ​​памяти или других ресурсах.
        ///Это устройство работает неправильно.Один из его драйверов или ваш реестр может быть поврежден. (4)
        ///Устройство работает неправильно.Один из его драйверов или реестра может быть поврежден.
        ///Драйверу для этого устройства нужен ресурс, который Windows не может управлять. (5)
        ///Драйверу для устройства требуется ресурс, который Windows не может управлять.
        ///Конфигурация загрузки для этого устройства конфликтует с другими устройствами. (6)
        ///Конфигурация загрузки для устройства конфликтует с другими устройствами.
        ///Невозможно фильтровать. (7)
        ///Загрузчик драйвера для устройства отсутствует. (8)
        ///Загрузчик драйвера для устройства отсутствует.
        ///Это устройство работает неправильно, потому что управляющая микропрограмма неправильно сообщает ресурсы для устройства. (9)
        ///Устройство работает неправильно.Контрольная микропрограмма неправильно сообщает ресурсы для устройства.
        ///Это устройство не может запускаться. (10)
        ///Устройство не может запускаться.
        ///Это устройство не удалось. (11)
        ///Ошибка устройства.
        ///Это устройство не может найти достаточно свободных ресурсов, которые он может использовать. (12)
        ///Устройство не может найти достаточно свободных ресурсов для использования.
        ///Windows не может проверить ресурсы этого устройства. (13)
        ///Windows не может проверить ресурсы устройства.
        ///Это устройство не может работать должным образом, пока вы не перезагрузите компьютер. (14)
        ///Устройство не может работать должным образом, пока компьютер не перезагрузится.
        ///Это устройство работает неправильно, потому что, вероятно, существует проблема повторного перечисления. (15)
        ///Устройство не работает должным образом из-за возможной проблемы повторного перечисления.
        ///Windows не может определить все ресурсы, используемые этим устройством. (16)
        ///Windows не может идентифицировать все ресурсы, которые использует устройство.
        ///Это устройство запрашивает неизвестный тип ресурса. (17)
        ///Устройство запрашивает неизвестный тип ресурса.
        ///Переустановите драйверы для этого устройства. (18)
        ///Драйверы устройств необходимо переустановить.
        ///Ошибка при использовании погрузчика VxD. (19)
        ///Возможно, ваш реестр поврежден. (20)
        ///Реестр может быть поврежден.
        ///Сбой системы: попробуйте изменить драйвер для этого устройства. Если это не сработает, см.Документацию по оборудованию.Windows удаляет это устройство. (21)
        ///Системная ошибка.Если изменение драйвера устройства неэффективно, см.Документацию по оборудованию.Windows удаляет устройство.
        ///Это устройство отключено. (22)
        ///Устройство отключено.
        ///Сбой системы: попробуйте изменить драйвер для этого устройства. Если это не сработает, см.Документацию по оборудованию. (23)
        ///Системная ошибка.Если изменение драйвера устройства неэффективно, см.Документацию по оборудованию.
        ///Это устройство отсутствует, не работает должным образом или не установлено все его драйверы. (24)
        ///Устройство отсутствует, не работает должным образом или не установлено все его драйверы.
        ///Windows все еще настраивает это устройство. (25)
        ///Windows все еще настраивает устройство.
        ///Windows все еще настраивает это устройство. (26)
        ///Windows все еще настраивает устройство.
        ///Это устройство не имеет правильной конфигурации журнала. (27)
        ///У устройства нет правильной конфигурации журнала.
        ///Драйверы для этого устройства не установлены. (28)
        ///Драйверы устройств не установлены.
        ///Это устройство отключено, потому что прошивка устройства не давала ему необходимых ресурсов. (29)
        ///Устройство отключено.Прошивка устройства не обеспечивала требуемые ресурсы.
        ///Это устройство использует ресурс запроса прерывания (IRQ), который использует другое устройство. (30)
        ///Устройство использует ресурс IRQ, который использует другое устройство.
        ///Это устройство работает неправильно, потому что Windows не может загрузить драйверы, необходимые для этого устройства. (31)*/
        /// </summary>
        uint ConfigManagerErrorCode;
        /// <summary>
        /// Уникальный идентификатор диска с другими устройствами в системе.
        /// </summary>
        string DeviceID;
        /// <summary>
        /// Версия для прошивки на диске, назначенная производителем.
        /// </summary>
        string FirmwareRevision;
        /// <summary>
        /// Номер физического диска данного диска. Значение 0xffffffff указывает, что данный диск не отображается на физический диск.
        /// </summary>
        uint Index;
        /// <summary>
        /// Тип интерфейса физического диска.
        /// </summary>
        string InterfaceType;
        /// <summary>
        /// Последний код ошибки, сообщенный логическим устройством.
        /// </summary>
        uint LastErrorCode;
        /// <summary>
        /// Тип носителя, используемого или доступного данным устройством.
        ///
        ///Возможные значения:
        ///External hard disk media(«Внешний носитель на жестком диске»)
        ///Removable media(«Сменные носители, кроме дискет»)
        ///Fixed hard disk («Исправлены жесткие диски»)
        ///Unknown(«Формат неизвестен»)
        /// </summary>
        string MediaType;
        /// <summary>
        /// Количество разделов на этом физическом диске, которые распознаются операционной системой.
        /// </summary>
        uint Partitions;
        /// <summary>
        /// Идентификатор устройства Windows Plug and Play логического устройства.
        /// </summary>
        string PNPDeviceID;
        /// <summary>
        /// Номер, выделенный изготовителем для идентификации физических носителей.
        /// </summary>
        string SerialNumber;
        /// <summary>
        /// Размер диска. Он рассчитывается путем умножения общего количества цилиндров, дорожек в каждом цилиндре, секторов на каждой дорожке и байтов в каждом секторе.
        /// </summary>
        ulong Size;
        /// <summary>
        /// Текущее состояние объекта. 
        ///
        /// OK («ОК»)
        /// Ошибка(«Ошибка»)
        /// Деградированные(«деградированные»)
        /// Неизвестно(«Неизвестно»)
        /// Pred Fail(«Pred Fail»)
        /// Запуск(«Запуск»)
        /// Остановка(«Остановка»)
        /// Сервис(«Сервис»)
        /// Подчеркнутый(«Подчеркнутый»)
        /// NonRecover("NonRecover")
        /// Нет контакта(«Без контакта»)
        /// Lost Comm(«Lost Comm»)
        /// </summary>
        string Status;
    }
#pragma warning restore CS0649
#pragma warning restore CS0169
    #endregion
}

