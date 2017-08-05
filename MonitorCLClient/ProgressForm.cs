using Microsoft.Win32;
using MonitorCLClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class ProgressForm : Form
    {
        ClientWork client = new ClientWork();

        string serialKey = "";

        public ProgressForm(string key)
        {
            InitializeComponent();
            serialKey = key;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            Show();
            client.IP = Properties.Settings.Default.ip;
            client.Port = Properties.Settings.Default.port;

            switch (client.Register(serialKey))
            {
                case ResultCode.OK:
                    DialogResult = DialogResult.OK;

                    try
                    {
                        RegistryKey reg = Registry.LocalMachine.OpenSubKey
                            ("SOFTWARE\\CompLife\\" + Application.ProductName + "\\", true);

                        reg.SetValue("SerialKey", Convert.ToBase64String(Encoding.UTF8.GetBytes(serialKey)));
                    }
                    catch (Exception err)
                    {
                        LogList.Add(err.Message);
                    }

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

        }
    }
}
