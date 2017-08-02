using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonitorCLClassLibrary;

namespace MonitorCLClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm(new ClientWork());
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(new ClientWork());
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendMessageForm form = new SendMessageForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "MainForm")
                    item.Focus();
            }
        }
    }
}
