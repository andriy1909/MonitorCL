namespace MonitorCLServer
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.tbDeviceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTypeDevice = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInformation = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.mtbLicenceKey = new System.Windows.Forms.MaskedTextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btCopy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btGenereteKey = new System.Windows.Forms.Button();
            this.btDeleteKey = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.lbNoSave = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDeviceName
            // 
            this.tbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDeviceName.Location = new System.Drawing.Point(157, 129);
            this.tbDeviceName.Name = "tbDeviceName";
            this.tbDeviceName.Size = new System.Drawing.Size(257, 21);
            this.tbDeviceName.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Название устройства";
            // 
            // cbTypeDevice
            // 
            this.cbTypeDevice.DisplayMember = "0";
            this.cbTypeDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTypeDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbTypeDevice.FormattingEnabled = true;
            this.cbTypeDevice.Items.AddRange(new object[] {
            "<Не извесно>",
            "Компютер",
            "Ноутбук",
            "Сервер"});
            this.cbTypeDevice.Location = new System.Drawing.Point(158, 100);
            this.cbTypeDevice.Name = "cbTypeDevice";
            this.cbTypeDevice.Size = new System.Drawing.Size(255, 23);
            this.cbTypeDevice.TabIndex = 25;
            this.cbTypeDevice.Text = "<Не извесно>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(49, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Тип устройства";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(53, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Пользователь";
            // 
            // tbUserName
            // 
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserName.Enabled = false;
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUserName.Location = new System.Drawing.Point(157, 18);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(257, 21);
            this.tbUserName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(85, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Телефон";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(34, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Доп. информация";
            // 
            // tbInformation
            // 
            this.tbInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInformation.Location = new System.Drawing.Point(157, 156);
            this.tbInformation.Multiline = true;
            this.tbInformation.Name = "tbInformation";
            this.tbInformation.Size = new System.Drawing.Size(257, 95);
            this.tbInformation.TabIndex = 20;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(157, 99);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(257, 25);
            this.textBox5.TabIndex = 28;
            // 
            // mtbPhone
            // 
            this.mtbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mtbPhone.Location = new System.Drawing.Point(157, 72);
            this.mtbPhone.Mask = "+38 (999) 000-0000";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(257, 21);
            this.mtbPhone.TabIndex = 29;
            // 
            // mtbLicenceKey
            // 
            this.mtbLicenceKey.BackColor = System.Drawing.SystemColors.Window;
            this.mtbLicenceKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbLicenceKey.Culture = new System.Globalization.CultureInfo("en-US");
            this.mtbLicenceKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mtbLicenceKey.Location = new System.Drawing.Point(8, 19);
            this.mtbLicenceKey.Mask = "AAAAA-AAAAA-AAAAA-AAAAA-AAAAA";
            this.mtbLicenceKey.Name = "mtbLicenceKey";
            this.mtbLicenceKey.ReadOnly = true;
            this.mtbLicenceKey.Size = new System.Drawing.Size(325, 22);
            this.mtbLicenceKey.TabIndex = 30;
            this.mtbLicenceKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.Menu;
            this.btCancel.FlatAppearance.BorderSize = 2;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.Location = new System.Drawing.Point(271, 400);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(72, 28);
            this.btCancel.TabIndex = 33;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = false;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.BackColor = System.Drawing.SystemColors.Menu;
            this.btOK.FlatAppearance.BorderSize = 2;
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOK.Location = new System.Drawing.Point(193, 400);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(72, 28);
            this.btOK.TabIndex = 34;
            this.btOK.Text = "ОК";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCopy
            // 
            this.btCopy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btCopy.BackgroundImage")));
            this.btCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCopy.FlatAppearance.BorderSize = 0;
            this.btCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCopy.Location = new System.Drawing.Point(337, 18);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(23, 23);
            this.btCopy.TabIndex = 35;
            this.btCopy.UseVisualStyleBackColor = true;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.btGenereteKey);
            this.groupBox1.Controls.Add(this.btDeleteKey);
            this.groupBox1.Controls.Add(this.mtbLicenceKey);
            this.groupBox1.Controls.Add(this.btCopy);
            this.groupBox1.Location = new System.Drawing.Point(42, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 110);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Лицензионый ключ";
            // 
            // btGenereteKey
            // 
            this.btGenereteKey.BackColor = System.Drawing.SystemColors.Menu;
            this.btGenereteKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenereteKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btGenereteKey.Location = new System.Drawing.Point(8, 79);
            this.btGenereteKey.Name = "btGenereteKey";
            this.btGenereteKey.Size = new System.Drawing.Size(103, 25);
            this.btGenereteKey.TabIndex = 37;
            this.btGenereteKey.Text = "Сгенерировать";
            this.btGenereteKey.UseVisualStyleBackColor = false;
            this.btGenereteKey.Click += new System.EventHandler(this.btGenereteKey_Click);
            // 
            // btDeleteKey
            // 
            this.btDeleteKey.BackColor = System.Drawing.SystemColors.Menu;
            this.btDeleteKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeleteKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDeleteKey.Location = new System.Drawing.Point(117, 79);
            this.btDeleteKey.Name = "btDeleteKey";
            this.btDeleteKey.Size = new System.Drawing.Size(67, 25);
            this.btDeleteKey.TabIndex = 36;
            this.btDeleteKey.Text = "Удалить";
            this.btDeleteKey.UseVisualStyleBackColor = false;
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.BackColor = System.Drawing.SystemColors.Menu;
            this.btApply.FlatAppearance.BorderSize = 2;
            this.btApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btApply.Location = new System.Drawing.Point(349, 400);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(88, 28);
            this.btApply.TabIndex = 37;
            this.btApply.Text = "Применить";
            this.btApply.UseVisualStyleBackColor = false;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // lbNoSave
            // 
            this.lbNoSave.ForeColor = System.Drawing.Color.Firebrick;
            this.lbNoSave.Location = new System.Drawing.Point(39, 370);
            this.lbNoSave.Name = "lbNoSave";
            this.lbNoSave.Size = new System.Drawing.Size(325, 17);
            this.lbNoSave.TabIndex = 38;
            this.lbNoSave.Text = "Сохраните изменения, чтобы активировать ключ";
            this.lbNoSave.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(79, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "Компания";
            // 
            // tbCompany
            // 
            this.tbCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCompany.Enabled = false;
            this.tbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCompany.Location = new System.Drawing.Point(157, 45);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(257, 21);
            this.tbCompany.TabIndex = 38;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd.mm.yyyy HH:MM";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(204, 47);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(129, 20);
            this.dtpDateTo.TabIndex = 38;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Help;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(103, 50);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 13);
            this.linkLabel1.TabIndex = 39;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Действителен до";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Время за которое пользователь должен первый раз ввести ключ в програму";
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(449, 440);
            this.Controls.Add(this.lbNoSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.mtbPhone);
            this.Controls.Add(this.tbDeviceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTypeDevice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbInformation);
            this.Controls.Add(this.textBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.Text = "Добавление пользователя";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDeviceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTypeDevice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInformation;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.MaskedTextBox mtbLicenceKey;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btGenereteKey;
        private System.Windows.Forms.Button btDeleteKey;
        private System.Windows.Forms.Label lbNoSave;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}