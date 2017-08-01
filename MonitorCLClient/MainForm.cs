using MonitorCLClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MonitorCLClassLibrary;

namespace MonitorCLClient
{
    public partial class MainForm : Form
    {
        ClientWork client = new ClientWork();
        bool canClose = false;
        SendMessageForm sendMessage = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProgressForm formP = new ProgressForm();
            if (formP.ShowDialog() != DialogResult.OK)
            {
                Exit();
            }

            if (Settings.Default.isBlocked)
            {
                Exit();
            }

            #region автозапуск программы при старте Windows
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (reg.GetValue(Application.ProductName).ToString() != Application.ExecutablePath.ToString())
                    reg.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            }
            catch (Exception err)
            {
                LogList.Add(err.Message);
            }
            #endregion

            if (Settings.Default.login == "")
            {
                RegistrationForm rForm = new RegistrationForm();
                if (rForm.ShowDialog() != DialogResult.OK || !rForm.isConnect)
                {
                    Exit();
                }
            }

            //TryConnect
            int result = Connect();
            switch (result)
            {
                case 0:// OK

                    break;
                case 1:// not auth

                    LoginForm form = new LoginForm();
                    form.ShowDialog();

                    break;
                case 2:// not found user
                    RegistrationForm rForm = new RegistrationForm();
                    if (rForm.ShowDialog() != DialogResult.OK || !rForm.isConnect)
                    {
                        Exit();
                    }
                    break;
                case 3:// block
                    Exit();
                    break;
                case 4:// error
                    //tryConnect
                    result = Connect(true);
                    if (result != 0)
                        Exit();
                    break;
                default:
                    //tryConnect
                    result = Connect(true);
                    if (result != 0)
                        Exit();
                    break;
            }


            tbIP.Text = Settings.Default.ip;
            tbPort.Text = Settings.Default.port.ToString();
        }

        /// <summary>
        /// Соединение с сервером
        /// 0-OK,1-not auth,2-not found user, 3-block, 4-error
        /// </summary>
        /// <returns>Статус</returns>
        private int Connect(bool tryConnect = false)
        {
            //try

            // client.Connect(Settings.Default.ip, Settings.Default.port, Settings.Default.login,Settings.Default.password);

            return 0;
        }

        /// <summary>
        /// Выход с программы
        /// </summary>
        private void Exit()
        {
            Process.GetCurrentProcess().Kill();
        }

        private void ErrorToSupport()
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;

                tbIP.Text = Settings.Default.ip;
                tbPort.Text = Settings.Default.port.ToString();
            }
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessageForm sm = new SendMessageForm(client);
            sm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
            {
                notifyIcon.Visible = false;
            }
            e.Cancel = !canClose;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canClose = true;
            notifyIcon.Visible = false;
            Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sendMessage = new SendMessageForm();
                sendMessage.Show();
                sendMessage.WindowState = FormWindowState.Normal;
                sendMessage.ShowInTaskbar = true;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            tbIP.Text = Settings.Default.ip;
            tbPort.Text = Settings.Default.port.ToString();
            Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            IPAddress ip = null;
            if (!IPAddress.TryParse(tbIP.Text, out ip))
            {
                MessageBox.Show("IP адресс имеет недопустимый формат!");
            }
            else
            if (Convert.ToInt32(tbPort.Text) <= 0)
            {
                MessageBox.Show("Введите номер порта!");
            }
            else
            {
                Settings.Default.ip = tbIP.Text;
                Settings.Default.port = int.Parse(tbPort.Text);
                Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();
            form.Show();
        }
    }
}
