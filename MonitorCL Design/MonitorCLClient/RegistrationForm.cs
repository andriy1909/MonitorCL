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

        public RegistrationForm() //форма повина або підключитись, або вийти з програми
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
            textBox1.UseSystemPasswordChar = true;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
