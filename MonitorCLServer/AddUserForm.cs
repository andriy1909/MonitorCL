using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MonitorCLClassLibrary.Model;
using System.Data.Entity;

namespace MonitorCLServer
{
    public partial class AddUserForm : Form
    {
        bool isAdd = false;
        User user = new User();
        TreeNode parentGroup = null;
        MonitoringDB db = new MonitoringDB();

        public AddUserForm(TreeNode parentGroup = null)
        {
            InitializeComponent();
            this.parentGroup = parentGroup;
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(mtbLicenceKey.Text);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            btApply_Click(sender, e);
            Close();
        }

        private void btGenereteKey_Click(object sender, EventArgs e)
        {
            //string newGuid = Guid.NewGuid().ToString().Replace("-", "").Remove(25, 7).ToUpper();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string resultKey = "";
            do
            {
                resultKey = "";
                RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
                byte[] key = new byte[25];
                rand.GetNonZeroBytes(key);
                foreach (var item in key)
                {
                    resultKey += chars[item % chars.Length];
                }

            } while (db.LicenceKeys.SingleOrDefault(x => x.Key == resultKey) != null);
            mtbLicenceKey.Text = resultKey;
            lbNoSave.Visible = true;
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (tbDeviceName.TextLength == 0)
            {
                MessageBox.Show("Введите название устройства (для оботражения)");
                return;
            }
            if (cbTypeDevice.Text == "")
            {
                MessageBox.Show("Виберете тип устройства!");
                return;
            }
            if (mtbLicenceKey.Text.Contains(' ') && MessageBox.Show("Для пользователя не сгенерирован ключ активации, сохранить без ключа?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }


            user.UserName = tbUserName.Text;
            user.DateReg = DateTime.Now;
            if (parentGroup != null)
            {
                if (parentGroup.Tag != null)
                    user.Group = db.UserGroups.Where(x => x.UsersGroupId == ((UsersGroup)parentGroup.Tag).UsersGroupId).First();
            }
            user.Information = tbInformation.Text;
            user.TypePC = cbTypeDevice.SelectedIndex;
            user.Phone = mtbPhone.Text;
            user.Company = tbCompany.Text;

            if (isAdd)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            else
            {
                if (user != null)
                {
                    db.Users.Attach(user);
                    db.Entry(this).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                    MessageBox.Show("Ошибка редактирования пользователя!");
                return;
            }

            if (!mtbLicenceKey.Text.Contains(' '))
            {
                LicenceKey licenseKey = new LicenceKey()
                {
                    Active = true,
                    DateExp = dtpDateTo.Value,
                    Key = mtbLicenceKey.Text,
                    User = user,
                    DateCreate = DateTime.Now,
                    UnicId = null
                };
                db.LicenceKeys.Add(licenseKey);
                db.SaveChanges();
                lbNoSave.Visible = false;
                btApply.Enabled = false;
            }
            else
                MessageBox.Show("Ошибка редактирования ключа!");

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            btApply.Enabled = true;
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!lbNoSave.Visible || MessageBox.Show("Закрить без сохранения?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btDeleteKey_Click(object sender, EventArgs e)
        {
            mtbLicenceKey.Text = "";
        }
    }
}
