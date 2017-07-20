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

namespace MonitorCLClient
{
    public partial class MainForm : Form
    {
        ClientWork client = new ClientWork();
        bool canClose = false;
        bool isConnected = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(Settings.Default.isBlocked)
            {
                Exit();
            }
            //автозапуск программы при старте Windows

            //TryConnect
            int result = Connect();
            switch (result)
            {
                case 0:// OK

                    break;
                case 1:// not auth
                    
                    break;
                case 2:// not found user
                    RegistrationForm rForm = new RegistrationForm();
                    if(rForm.ShowDialog()!=DialogResult.OK||!rForm.isConnect)
                    {
                        Exit();
                    }
                    break;
                case 3:// block
                    Exit();
                    break;
                case 4:// error
                    //tryConnect
                    if (result != 0)
                        Exit();
                    break;
                default:
                    //tryConnect
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
        private int Connect()
        {
            //try
            return -1;
        }

        /// <summary>
        /// Выход с программы
        /// </summary>
        private void Exit()
        {
            throw new NotImplementedException();
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
                tbLogin.Text = Settings.Default.login;
                tbPassword.Text = Settings.Default.password;
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
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            tbIP.Text = Settings.Default.ip;
            tbPort.Text = Settings.Default.port.ToString();
            tbLogin.Text = Settings.Default.login;
            tbPassword.Text = Settings.Default.password;
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
            if (tbLogin.Text == "")
            {
                MessageBox.Show("Введите логин!");
            }
            else
            if (tbPassword.Text == "")
            {
                MessageBox.Show("Введите пароль!");
            }
            else
            {
                Settings.Default.ip = tbIP.Text;
                Settings.Default.port = int.Parse(tbPort.Text);
                Settings.Default.login = tbLogin.Text;
                Settings.Default.password = tbPassword.Text;
                Close();
            }
        }
    }
}
