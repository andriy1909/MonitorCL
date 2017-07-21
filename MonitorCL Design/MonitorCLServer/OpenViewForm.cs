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
    public partial class OpenViewForm : Form
    {
        public OpenViewForm()
        {
            InitializeComponent();
        }

        private void OpenViewForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                null,
                DateTime.Now.AddDays(-new Random().Next(DateTime.Now.Day)).AddMonths(-new Random().Next(3)),
                "Установленые программы"
                });
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_CheckStateChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                toolStripButton1.BackColor = Color.LightGray;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                toolStripButton1.BackColor = Color.White;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }
    }
}
