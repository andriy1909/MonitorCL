using Microsoft.Win32;
using MonitorCLClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class ProgressForm : Form
    {
        ClientWork client = new ClientWork();
        Thread thread;

        string serialKey = "";

        public ProgressForm(string key)
        {
            InitializeComponent();
            serialKey = key;
        }

        public ClientWork GetClient()
        {
            return client;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            Show();
            thread = new Thread(Connect);
            thread.Start();
        }

        void Connect()
        {
            client.IP = Properties.Settings.Default.ip;
            client.Port = Properties.Settings.Default.port;

            switch (client.Register(serialKey))
            {
                case ResultCode.OK:

                    MessageBox.Show("Регистрация выполнена!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                    client.SetActiveKey(serialKey);

                    Close();
                    break;
                case ResultCode.NotValidKey:
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Ключ не действителен!", "Ошибка активации!");
                    Close();
                    break;
                case ResultCode.KeyTimeout:
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Ключ больше не действителен!", "Ошибка активации!");
                    Close();
                    break;
                case ResultCode.NoConnection:
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Нет соединения с сервером. Проверте соединение с интернетом и попробуйте повторить попитку позже.", "Ошибка соединения!");
                    Close();
                    break;
                default:
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Ошибка соединения с сервером.", "Ошибка соединения!");
                    Close();
                    break;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Соединение прервано!", "Ошибка соединения!");
        }
    }
}
