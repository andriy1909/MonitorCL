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
    public partial class RegistrationForm : Form
    {
        public bool isConnect = false;

        public RegistrationForm() 
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
            tbPasswordConfirm.UseSystemPasswordChar = true;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog(Parent);
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            ProgressForm form = new ProgressForm();
            this.Hide();
            if(form.ShowDialog()==DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                switch (form.errorCode)
                {
                    case 1:
                        lbNotConnection.Visible = true;
                        break;
                    case 2:
                        lbLoginExist.Visible = true;
                        break;
                    default:
                        break;
                }
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
