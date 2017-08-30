using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonitorCLClassLibrary.Model;
using System.Data.Entity;

namespace MonitorCLServer
{
    public partial class AddGroupForm : Form
    {
        TreeNode parentNode = null;
        UsersGroup group = new UsersGroup();
        bool isAdd = false;

        public AddGroupForm(TreeNode parentNode = null)
        {
            InitializeComponent();
            isAdd = true;
            this.parentNode = parentNode;
        }

        public AddGroupForm(UsersGroup group)
        {
            InitializeComponent();
            isAdd = false;
            this.group = group ?? throw new ArgumentNullException("group");
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {
            if(isAdd)
            {
                tbGroupName.Text = group.Name;
                tbInformation.Text = group.Information;
            }
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
                group.Name = tbGroupName.Text;
                group.Information = tbInformation.Text;
                group.Level = 0;
                if(parentNode != null)
                {
                    if (parentNode.Tag != null)
                        group.Parent = db.UserGroups.Where(x => x.UsersGroupId == ((UsersGroup)parentNode.Tag).UsersGroupId).First();
                    group.Level = parentNode.Level + 1;
                }

                if (isAdd)
                {
                    db.UserGroups.Add(group);
                }
                else
                {
                    db.UserGroups.Attach(group);
                    db.Entry(db.UserGroups.Find(group.UsersGroupId)).State = EntityState.Modified;
                }
                db.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
