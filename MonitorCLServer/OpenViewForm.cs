using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public partial class OpenViewForm : Form
    {
        public bool locked = true;

        public OpenViewForm()
        {
            InitializeComponent();
        }
        ProductsControl productsControl1 = new ProductsControl();


        private void OpenViewForm_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Add(productsControl1);
            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                null,
                DateTime.Now.AddDays(-new Random(i).Next(DateTime.Now.Day)).AddMonths(-new Random(i).Next(3)),
                "Установленые программы"
                });
            }
        }

        void paint()
        {
            for (int i = 0; i < 20; i++)
            {
                productsControl1.setColor(i, Color.White);
            }
            for (int i = 0; i < 3; i++)
            {
                productsControl1.setColor(new Random().Next(20), Color.LightGreen);
                Thread.Sleep(100);
            }
            productsControl1.setColor(new Random().Next(20), Color.IndianRed);
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
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                toolStripButton1.BackColor = Color.White;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Index != 0)
            {
                dataGridView1.Rows[dataGridView1.SelectedRows[0].Index - 1].Selected = true;
            }
            paint();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Index != dataGridView1.RowCount - 1)
            {
                dataGridView1.Rows[dataGridView1.SelectedRows[0].Index + 1].Selected = true;
            }
            paint();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            paint();
        }
    }
}
