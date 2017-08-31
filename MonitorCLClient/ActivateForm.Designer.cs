namespace MonitorCLClient
{
    partial class ActivateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivateForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btActivate = new System.Windows.Forms.Button();
            this.mtbLicenceKey = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(58, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ключ активации";
            // 
            // btActivate
            // 
            this.btActivate.BackColor = System.Drawing.SystemColors.Menu;
            this.btActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btActivate.Location = new System.Drawing.Point(474, 216);
            this.btActivate.Name = "btActivate";
            this.btActivate.Size = new System.Drawing.Size(91, 29);
            this.btActivate.TabIndex = 1;
            this.btActivate.Text = "Активация";
            this.btActivate.UseVisualStyleBackColor = false;
            this.btActivate.Click += new System.EventHandler(this.btActivate_Click);
            // 
            // mtbLicenceKey
            // 
            this.mtbLicenceKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbLicenceKey.Culture = new System.Globalization.CultureInfo("en-US");
            this.mtbLicenceKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mtbLicenceKey.Location = new System.Drawing.Point(95, 220);
            this.mtbLicenceKey.Mask = "AAAAA-AAAAA-AAAAA-AAAAA-AAAAA";
            this.mtbLicenceKey.Name = "mtbLicenceKey";
            this.mtbLicenceKey.Size = new System.Drawing.Size(347, 22);
            this.mtbLicenceKey.TabIndex = 3;
            this.mtbLicenceKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLicenceKey.Leave += new System.EventHandler(this.mtbLicenceKey_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(309, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 114);
            this.label2.TabIndex = 5;
            this.label2.Text = "Для использования программы нужно получить ключ активации у менеджеров компании C" +
    "ompLife.\r\n\r\n\r\nТелефон:  +38 (097) 745-29-82\r\nE-mail:    office@complife.ua\r\n";
            // 
            // ActivateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(577, 289);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mtbLicenceKey);
            this.Controls.Add(this.btActivate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Активация программы";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btActivate;
        private System.Windows.Forms.MaskedTextBox mtbLicenceKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}