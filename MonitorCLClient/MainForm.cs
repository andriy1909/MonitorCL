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
using MonitorCLClassLibrary.JSON;

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
            lbVersion.Text += Application.ProductVersion + "b";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (client.GetLicenseKey() != null)
            {
                client.SetAutoRun(Application.ExecutablePath, true);
                client.IP = (Settings.Default.ip=="")?"127.0.0.1": Settings.Default.ip;
                client.Port = (Settings.Default.port == 0) ? 11000 : Settings.Default.port;
                if (client.Login())
                {

                }
                else
                {

                }
            }
            else
            {
                ActivateForm aForm = new ActivateForm();
                if (aForm.ShowDialog() == DialogResult.OK)
                {
                    Exit();
                }
                else
                {
                    Exit();
                }
            }
            

            // client.SetAutoRun(Application.ExecutablePath, true); //автозапуск программы при старте Windows



        }

        /// <summary>
        /// Соединение с сервером
        /// </summary>
        /// <returns>Статус</returns>
        private ResultCode Connect(bool tryConnect = false)
        {
            client.Connect_Delete();
            Thread.Sleep(5000);

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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void linkCompLife_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.complife.ua");
        }
    }
}
