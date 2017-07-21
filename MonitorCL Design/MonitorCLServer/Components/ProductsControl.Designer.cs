namespace MonitorCLServer
{
    partial class ProductsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsControl));
            this.dataGridView0 = new System.Windows.Forms.DataGridView();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentifyingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstallDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView0
            // 
            this.dataGridView0.AllowUserToAddRows = false;
            this.dataGridView0.AllowUserToDeleteRows = false;
            this.dataGridView0.AllowUserToResizeRows = false;
            this.dataGridView0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView0.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameProduct,
            this.IdentifyingNumber,
            this.InstallDate,
            this.Column4,
            this.Column5,
            this.Column1});
            this.dataGridView0.Location = new System.Drawing.Point(385, 426);
            this.dataGridView0.MultiSelect = false;
            this.dataGridView0.Name = "dataGridView0";
            this.dataGridView0.ReadOnly = true;
            this.dataGridView0.RowHeadersVisible = false;
            this.dataGridView0.Size = new System.Drawing.Size(302, 102);
            this.dataGridView0.TabIndex = 0;
            this.dataGridView0.Visible = false;
            // 
            // NameProduct
            // 
            this.NameProduct.HeaderText = "Назва";
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.ReadOnly = true;
            // 
            // IdentifyingNumber
            // 
            this.IdentifyingNumber.HeaderText = "Ідентифікатор";
            this.IdentifyingNumber.Name = "IdentifyingNumber";
            this.IdentifyingNumber.ReadOnly = true;
            // 
            // InstallDate
            // 
            this.InstallDate.HeaderText = "Дата установки";
            this.InstallDate.Name = "InstallDate";
            this.InstallDate.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Розміщення";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Постачальник";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Версія";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 3);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(687, 528);
            this.dataGridView1.TabIndex = 5;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "";
            this.Column3.MinimumWidth = 20;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 20;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "3floppy_unmount_4228.png");
            this.imageList1.Images.SetKeyName(1, "3floppy_unmount_42282.png");
            this.imageList1.Images.SetKeyName(2, "31100.png");
            this.imageList1.Images.SetKeyName(3, "apply_4612.png");
            this.imageList1.Images.SetKeyName(4, "computer_1672.png");
            this.imageList1.Images.SetKeyName(5, "computer_network-128.png");
            this.imageList1.Images.SetKeyName(6, "computer-tower-and-monitor_icon-icons.com_56305.png");
            this.imageList1.Images.SetKeyName(7, "delete_9807.png");
            this.imageList1.Images.SetKeyName(8, "deletered_7813.png");
            this.imageList1.Images.SetKeyName(9, "drive-harddisk_2030.png");
            this.imageList1.Images.SetKeyName(10, "editprofile_5327.png");
            this.imageList1.Images.SetKeyName(11, "floppy-64_1966.png");
            this.imageList1.Images.SetKeyName(12, "friendfinder_4416.png");
            this.imageList1.Images.SetKeyName(13, "Hosting-two.jpg");
            this.imageList1.Images.SetKeyName(14, "kpowersave_6369.png");
            this.imageList1.Images.SetKeyName(15, "mycomputer_3432.png");
            this.imageList1.Images.SetKeyName(16, "network-lan_6251.png");
            this.imageList1.Images.SetKeyName(17, "Notebook.png");
            this.imageList1.Images.SetKeyName(18, "old-view-refresh_8928.png");
            this.imageList1.Images.SetKeyName(19, "pencil_1327.png");
            this.imageList1.Images.SetKeyName(20, "preferences-desktop-user_3510.png");
            this.imageList1.Images.SetKeyName(21, "send_9942.ico");
            this.imageList1.Images.SetKeyName(22, "serversicon.png");
            this.imageList1.Images.SetKeyName(23, "setting_5376.ico");
            this.imageList1.Images.SetKeyName(24, "status_unknown_3086.png");
            this.imageList1.Images.SetKeyName(25, "Без названия.jpg");
            // 
            // ProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView0);
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(687, 528);
            this.Load += new System.EventHandler(this.ProductsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView0;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentifyingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstallDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}
