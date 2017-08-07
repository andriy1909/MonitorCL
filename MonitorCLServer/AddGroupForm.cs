using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonitorCLClassLibrary.Model;

namespace MonitorCLServer
{
    public partial class AddGroupForm : Form
    {
        TreeNode parentNode = null;

        public AddGroupForm(TreeNode parentNode = null)
        {
            InitializeComponent();
            this.parentNode = parentNode;
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (tbGroupName.TextLength == 0)
            {
                MessageBox.Show("Введите название группы!");
            }
            else
            {
                var db = new MonitoringDB();
                UsersGroup group = new UsersGroup()
                {
                    Name = tbGroupName.Text,
                    Information = tbInformation.Text,
                    Level = 0
                };
                if(parentNode != null)
                {
                    if (parentNode.Tag != null)
                        group.Parent = db.UserGroups.Where(x => x.UsersGroupId == ((UsersGroup)parentNode.Tag).UsersGroupId).First();
                    group.Level = parentNode.Level + 1;
                }
                db.UserGroups.Add(group);
                db.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
