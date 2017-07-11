using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
            DialogResult = DialogResult.Cancel;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == Properties.Settings.Default.login && tbPassword.Text == Properties.Settings.Default.password)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, "Пароль или логин введен неверно!","Ошибка входа",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
