using MonitorCLClassLibrary;
using MonitorCLClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class MainForm : Form
    {
        ClientWork client = new ClientWork();
        bool canClose = false;

        public MainForm()
        {
            InitializeComponent();
        }

        public void Receive(string message)
        {

        }

        public void IsConnected(bool check)
        {
            if (check)
            {

            }
            else
            {

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
            tbIP.Text = Settings.Default.ip;
            tbPort.Text = Settings.Default.port.ToString();
            tbLogin.Text = Settings.Default.login;
            tbPassword.Text = Settings.Default.password;
            
            client.setReceiveOut(Receive);
            client.setIsConnectOut(IsConnected);
            client.Connect(Settings.Default.ip, Settings.Default.port, Settings.Default.id, Settings.Default.login, Settings.Default.password);

            /*  var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
              if (key.GetValue(Application.ProductName).ToString() == Application.ExecutablePath)
              {
                  //автозапуск программы при старте Windows
                  key.SetValue(Application.ProductName, Application.ExecutablePath);
              }*/
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
            System.Diagnostics.Process.GetCurrentProcess().Kill();
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
                client.Connect(Settings.Default.ip, Settings.Default.port, Settings.Default.id, Settings.Default.login, Settings.Default.password);
                if (!client.IsConnect)
                    if (MessageBox.Show("Не получилось подключится!" + Environment.NewLine + "Изменить параметры подключения?", "Ошибка", MessageBoxButtons.YesNo) == DialogResult.No)
                        Close();
            }
        }


        /*
        


private void MainForm_Load(object sender, EventArgs e)
{
client.setReceiveOut(Receive);
client.Connect(Settings.Default.ip, Settings.Default.port, Settings.Default.id);
}

private void button2_Click(object sender, EventArgs e)
{
client.SendMessage(tbIP.Text);
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
*/

    }
}
