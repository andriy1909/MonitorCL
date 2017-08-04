using MonitorCLClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MonitorCLClient
{
    public partial class RegistrationForm : Form
    {
        ClientWork client;
        public bool isConnect = false;

        public RegistrationForm(ClientWork client)
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
            tbPasswordConfirm.UseSystemPasswordChar = true;
            this.client = client;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm(client);
            form.ShowDialog(Parent);
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            IPAddress tmpIP;
            if (tbLogin.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return;
            }
            else
                if (tbPassword.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            else
                if (tbPassword.Text != tbPasswordConfirm.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            else
                if (!IPAddress.TryParse(tbIP.Text, out tmpIP))
            {
                MessageBox.Show("IP адресс введен неверно!");
                return;
            }

            Computer computer = new Computer();
            computer.UnicID = BaseBoard.GetSerialNumber();
            computer.User = new User()
            {
                Company = tbCompany.Text,
                DateReg = DateTime.Now,
                Login = tbLogin.Text,
                Name = tbName.Text,
                Password = tbPassword.Text
            };

            client.computer = computer;
            client.IP = tbIP.Text;
            client.Port = (int)numPort.Value; 

      /*      ProgressForm form = new ProgressForm(client);
            this.Hide();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                switch (form.errorCode)
                {
                    case 1:
                    case 3:
                        lbNotConnection.Visible = true;
                        break;
                    case 2:
                        lbLoginExist.Visible = true;
                        break;
                    default:
                        break;
                }
                this.Show();
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
