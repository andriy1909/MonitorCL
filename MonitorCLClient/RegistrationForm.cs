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

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog(Parent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ожидайте подтверждения!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
