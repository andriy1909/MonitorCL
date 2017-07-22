namespace WinScaner
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btWin32_BootConfiguration = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.btWin32_Process = new System.Windows.Forms.Button();
            this.btWin32_OperatingSystem = new System.Windows.Forms.Button();
            this.btWin32_DiskDrive = new System.Windows.Forms.Button();
            this.btWin32_BaseBoard = new System.Windows.Forms.Button();
            this.btWin32_BIOS = new System.Windows.Forms.Button();
            this.btWin32_OnBoardDevice = new System.Windows.Forms.Button();
            this.btWin32_PhysicalMemory = new System.Windows.Forms.Button();
            this.btWin32_Printer = new System.Windows.Forms.Button();
            this.btWin32_MotherboardDevice = new System.Windows.Forms.Button();
            this.btWin32_Processor = new System.Windows.Forms.Button();
            this.btWin32_StartupCommand = new System.Windows.Forms.Button();
            this.btWin32_NetworkAdapter = new System.Windows.Forms.Button();
            this.btWin32_Battery = new System.Windows.Forms.Button();
            this.btWin32_ParallelPort = new System.Windows.Forms.Button();
            this.btWin32_NetworkAdapterConfiguration = new System.Windows.Forms.Button();
            this.btWin32_PortConnector = new System.Windows.Forms.Button();
            this.btWin32_PortResource = new System.Windows.Forms.Button();
            this.btWin32_PortableBattery = new System.Windows.Forms.Button();
            this.btWin32_Product = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // btWin32_BootConfiguration
            // 
            this.btWin32_BootConfiguration.Location = new System.Drawing.Point(12, 12);
            this.btWin32_BootConfiguration.Name = "btWin32_BootConfiguration";
            this.btWin32_BootConfiguration.Size = new System.Drawing.Size(152, 23);
            this.btWin32_BootConfiguration.TabIndex = 0;
            this.btWin32_BootConfiguration.Text = "Win32_BootConfiguration";
            this.btWin32_BootConfiguration.UseVisualStyleBackColor = true;
            this.btWin32_BootConfiguration.Click += new System.EventHandler(this.btWin32_BootConfiguration_Click);
            // 
            // bt2
            // 
            this.bt2.Location = new System.Drawing.Point(12, 41);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(152, 23);
            this.bt2.TabIndex = 2;
            this.bt2.Text = "Win32_LogicalProgramGroup";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.btWin32_LogicalProgramGroup_Click);
            // 
            // btWin32_Process
            // 
            this.btWin32_Process.Location = new System.Drawing.Point(12, 70);
            this.btWin32_Process.Name = "btWin32_Process";
            this.btWin32_Process.Size = new System.Drawing.Size(152, 23);
            this.btWin32_Process.TabIndex = 3;
            this.btWin32_Process.Text = "Win32_Process ";
            this.btWin32_Process.UseVisualStyleBackColor = true;
            this.btWin32_Process.Click += new System.EventHandler(this.btWin32_Process_Click);
            // 
            // btWin32_OperatingSystem
            // 
            this.btWin32_OperatingSystem.Location = new System.Drawing.Point(12, 99);
            this.btWin32_OperatingSystem.Name = "btWin32_OperatingSystem";
            this.btWin32_OperatingSystem.Size = new System.Drawing.Size(152, 23);
            this.btWin32_OperatingSystem.TabIndex = 4;
            this.btWin32_OperatingSystem.Text = "Win32_OperatingSystem";
            this.btWin32_OperatingSystem.UseVisualStyleBackColor = true;
            this.btWin32_OperatingSystem.Click += new System.EventHandler(this.btWin32_OperatingSystem_Click);
            // 
            // btWin32_DiskDrive
            // 
            this.btWin32_DiskDrive.Location = new System.Drawing.Point(12, 128);
            this.btWin32_DiskDrive.Name = "btWin32_DiskDrive";
            this.btWin32_DiskDrive.Size = new System.Drawing.Size(152, 23);
            this.btWin32_DiskDrive.TabIndex = 5;
            this.btWin32_DiskDrive.Text = "Win32_DiskDrive ";
            this.btWin32_DiskDrive.UseVisualStyleBackColor = true;
            this.btWin32_DiskDrive.Click += new System.EventHandler(this.btWin32_DiskDrive_Click);
            // 
            // btWin32_BaseBoard
            // 
            this.btWin32_BaseBoard.Location = new System.Drawing.Point(12, 157);
            this.btWin32_BaseBoard.Name = "btWin32_BaseBoard";
            this.btWin32_BaseBoard.Size = new System.Drawing.Size(152, 23);
            this.btWin32_BaseBoard.TabIndex = 6;
            this.btWin32_BaseBoard.Text = "Win32_BaseBoard";
            this.btWin32_BaseBoard.UseVisualStyleBackColor = true;
            this.btWin32_BaseBoard.Click += new System.EventHandler(this.btWin32_BaseBoard_Click);
            // 
            // btWin32_BIOS
            // 
            this.btWin32_BIOS.Location = new System.Drawing.Point(12, 186);
            this.btWin32_BIOS.Name = "btWin32_BIOS";
            this.btWin32_BIOS.Size = new System.Drawing.Size(152, 23);
            this.btWin32_BIOS.TabIndex = 7;
            this.btWin32_BIOS.Text = "Win32_BIOS ";
            this.btWin32_BIOS.UseVisualStyleBackColor = true;
            this.btWin32_BIOS.Click += new System.EventHandler(this.btWin32_BIOS_Click);
            // 
            // btWin32_OnBoardDevice
            // 
            this.btWin32_OnBoardDevice.Location = new System.Drawing.Point(12, 215);
            this.btWin32_OnBoardDevice.Name = "btWin32_OnBoardDevice";
            this.btWin32_OnBoardDevice.Size = new System.Drawing.Size(152, 23);
            this.btWin32_OnBoardDevice.TabIndex = 8;
            this.btWin32_OnBoardDevice.Text = "Win32_OnBoardDevice";
            this.btWin32_OnBoardDevice.UseVisualStyleBackColor = true;
            this.btWin32_OnBoardDevice.Click += new System.EventHandler(this.btWin32_OnBoardDevice_Click);
            // 
            // btWin32_PhysicalMemory
            // 
            this.btWin32_PhysicalMemory.Location = new System.Drawing.Point(12, 244);
            this.btWin32_PhysicalMemory.Name = "btWin32_PhysicalMemory";
            this.btWin32_PhysicalMemory.Size = new System.Drawing.Size(152, 23);
            this.btWin32_PhysicalMemory.TabIndex = 9;
            this.btWin32_PhysicalMemory.Text = "Win32_PhysicalMemory";
            this.btWin32_PhysicalMemory.UseVisualStyleBackColor = true;
            this.btWin32_PhysicalMemory.Click += new System.EventHandler(this.btWin32_PhysicalMemory_Click);
            // 
            // btWin32_Printer
            // 
            this.btWin32_Printer.Location = new System.Drawing.Point(12, 360);
            this.btWin32_Printer.Name = "btWin32_Printer";
            this.btWin32_Printer.Size = new System.Drawing.Size(152, 23);
            this.btWin32_Printer.TabIndex = 13;
            this.btWin32_Printer.Text = "Win32_Printer";
            this.btWin32_Printer.UseVisualStyleBackColor = true;
            this.btWin32_Printer.Click += new System.EventHandler(this.btWin32_Printer_Click);
            // 
            // btWin32_MotherboardDevice
            // 
            this.btWin32_MotherboardDevice.Location = new System.Drawing.Point(12, 331);
            this.btWin32_MotherboardDevice.Name = "btWin32_MotherboardDevice";
            this.btWin32_MotherboardDevice.Size = new System.Drawing.Size(152, 23);
            this.btWin32_MotherboardDevice.TabIndex = 12;
            this.btWin32_MotherboardDevice.Text = "Win32_MotherboardDevice";
            this.btWin32_MotherboardDevice.UseVisualStyleBackColor = true;
            this.btWin32_MotherboardDevice.Click += new System.EventHandler(this.btWin32_MotherboardDevice_Click);
            // 
            // btWin32_Processor
            // 
            this.btWin32_Processor.Location = new System.Drawing.Point(12, 302);
            this.btWin32_Processor.Name = "btWin32_Processor";
            this.btWin32_Processor.Size = new System.Drawing.Size(152, 23);
            this.btWin32_Processor.TabIndex = 11;
            this.btWin32_Processor.Text = "Win32_Processor";
            this.btWin32_Processor.UseVisualStyleBackColor = true;
            this.btWin32_Processor.Click += new System.EventHandler(this.btWin32_Processor_Click);
            // 
            // btWin32_StartupCommand
            // 
            this.btWin32_StartupCommand.Location = new System.Drawing.Point(12, 273);
            this.btWin32_StartupCommand.Name = "btWin32_StartupCommand";
            this.btWin32_StartupCommand.Size = new System.Drawing.Size(152, 23);
            this.btWin32_StartupCommand.TabIndex = 10;
            this.btWin32_StartupCommand.Text = "Win32_StartupCommand";
            this.btWin32_StartupCommand.UseVisualStyleBackColor = true;
            this.btWin32_StartupCommand.Click += new System.EventHandler(this.btWin32_StartupCommand_Click);
            // 
            // btWin32_NetworkAdapter
            // 
            this.btWin32_NetworkAdapter.Location = new System.Drawing.Point(12, 418);
            this.btWin32_NetworkAdapter.Name = "btWin32_NetworkAdapter";
            this.btWin32_NetworkAdapter.Size = new System.Drawing.Size(152, 23);
            this.btWin32_NetworkAdapter.TabIndex = 15;
            this.btWin32_NetworkAdapter.Text = "Win32_NetworkAdapter";
            this.btWin32_NetworkAdapter.UseVisualStyleBackColor = true;
            this.btWin32_NetworkAdapter.Click += new System.EventHandler(this.btWin32_NetworkAdapter_Click);
            // 
            // btWin32_Battery
            // 
            this.btWin32_Battery.Location = new System.Drawing.Point(12, 389);
            this.btWin32_Battery.Name = "btWin32_Battery";
            this.btWin32_Battery.Size = new System.Drawing.Size(152, 23);
            this.btWin32_Battery.TabIndex = 14;
            this.btWin32_Battery.Text = "Win32_Battery";
            this.btWin32_Battery.UseVisualStyleBackColor = true;
            this.btWin32_Battery.Click += new System.EventHandler(this.btWin32_Battery_Click);
            // 
            // btWin32_ParallelPort
            // 
            this.btWin32_ParallelPort.Location = new System.Drawing.Point(12, 476);
            this.btWin32_ParallelPort.Name = "btWin32_ParallelPort";
            this.btWin32_ParallelPort.Size = new System.Drawing.Size(152, 23);
            this.btWin32_ParallelPort.TabIndex = 18;
            this.btWin32_ParallelPort.Text = "Win32_ParallelPort";
            this.btWin32_ParallelPort.UseVisualStyleBackColor = true;
            this.btWin32_ParallelPort.Click += new System.EventHandler(this.btWin32_ParallelPort_Click);
            // 
            // btWin32_NetworkAdapterConfiguration
            // 
            this.btWin32_NetworkAdapterConfiguration.Location = new System.Drawing.Point(12, 447);
            this.btWin32_NetworkAdapterConfiguration.Name = "btWin32_NetworkAdapterConfiguration";
            this.btWin32_NetworkAdapterConfiguration.Size = new System.Drawing.Size(152, 23);
            this.btWin32_NetworkAdapterConfiguration.TabIndex = 17;
            this.btWin32_NetworkAdapterConfiguration.Text = "Win32_NetworkAdapterConfiguration ";
            this.btWin32_NetworkAdapterConfiguration.UseVisualStyleBackColor = true;
            this.btWin32_NetworkAdapterConfiguration.Click += new System.EventHandler(this.btWin32_NetworkAdapterConfiguration_Click);
            // 
            // btWin32_PortConnector
            // 
            this.btWin32_PortConnector.Location = new System.Drawing.Point(12, 563);
            this.btWin32_PortConnector.Name = "btWin32_PortConnector";
            this.btWin32_PortConnector.Size = new System.Drawing.Size(152, 23);
            this.btWin32_PortConnector.TabIndex = 21;
            this.btWin32_PortConnector.Text = "Win32_PortConnector";
            this.btWin32_PortConnector.UseVisualStyleBackColor = true;
            this.btWin32_PortConnector.Click += new System.EventHandler(this.btWin32_PortConnector_Click);
            // 
            // btWin32_PortResource
            // 
            this.btWin32_PortResource.Location = new System.Drawing.Point(12, 534);
            this.btWin32_PortResource.Name = "btWin32_PortResource";
            this.btWin32_PortResource.Size = new System.Drawing.Size(152, 23);
            this.btWin32_PortResource.TabIndex = 20;
            this.btWin32_PortResource.Text = "Win32_PortResource";
            this.btWin32_PortResource.UseVisualStyleBackColor = true;
            this.btWin32_PortResource.Click += new System.EventHandler(this.btWin32_PortResource_Click);
            // 
            // btWin32_PortableBattery
            // 
            this.btWin32_PortableBattery.Location = new System.Drawing.Point(12, 505);
            this.btWin32_PortableBattery.Name = "btWin32_PortableBattery";
            this.btWin32_PortableBattery.Size = new System.Drawing.Size(152, 23);
            this.btWin32_PortableBattery.TabIndex = 19;
            this.btWin32_PortableBattery.Text = "Win32_PortableBattery";
            this.btWin32_PortableBattery.UseVisualStyleBackColor = true;
            this.btWin32_PortableBattery.Click += new System.EventHandler(this.btWin32_PortableBattery_Click);
            // 
            // btWin32_Product
            // 
            this.btWin32_Product.Location = new System.Drawing.Point(12, 592);
            this.btWin32_Product.Name = "btWin32_Product";
            this.btWin32_Product.Size = new System.Drawing.Size(152, 23);
            this.btWin32_Product.TabIndex = 22;
            this.btWin32_Product.Text = "Win32_Product";
            this.btWin32_Product.UseVisualStyleBackColor = true;
            this.btWin32_Product.Click += new System.EventHandler(this.btWin32_Product_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.Location = new System.Drawing.Point(52, 650);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(56, 23);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(170, 653);
            this.progressBar1.Maximum = 22;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(856, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 24;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 627);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "load";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(170, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(847, 635);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 26;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(847, 202);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 311;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Width = 311;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView3);
            this.splitContainer2.Size = new System.Drawing.Size(847, 429);
            this.splitContainer2.SplitterDistance = 224;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(847, 224);
            this.dataGridView2.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 311;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 311;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(847, 201);
            this.dataGridView3.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 311;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 311;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(101, 630);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(49, 17);
            this.checkBox2.TabIndex = 27;
            this.checkBox2.Text = "save";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 679);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btWin32_Product);
            this.Controls.Add(this.btWin32_PortConnector);
            this.Controls.Add(this.btWin32_PortResource);
            this.Controls.Add(this.btWin32_PortableBattery);
            this.Controls.Add(this.btWin32_ParallelPort);
            this.Controls.Add(this.btWin32_NetworkAdapterConfiguration);
            this.Controls.Add(this.btWin32_NetworkAdapter);
            this.Controls.Add(this.btWin32_Battery);
            this.Controls.Add(this.btWin32_Printer);
            this.Controls.Add(this.btWin32_MotherboardDevice);
            this.Controls.Add(this.btWin32_Processor);
            this.Controls.Add(this.btWin32_StartupCommand);
            this.Controls.Add(this.btWin32_BootConfiguration);
            this.Controls.Add(this.btWin32_PhysicalMemory);
            this.Controls.Add(this.btWin32_OnBoardDevice);
            this.Controls.Add(this.btWin32_BIOS);
            this.Controls.Add(this.btWin32_BaseBoard);
            this.Controls.Add(this.btWin32_DiskDrive);
            this.Controls.Add(this.btWin32_OperatingSystem);
            this.Controls.Add(this.btWin32_Process);
            this.Controls.Add(this.bt2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btWin32_BootConfiguration;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button btWin32_Process;
        private System.Windows.Forms.Button btWin32_OperatingSystem;
        private System.Windows.Forms.Button btWin32_DiskDrive;
        private System.Windows.Forms.Button btWin32_BaseBoard;
        private System.Windows.Forms.Button btWin32_BIOS;
        private System.Windows.Forms.Button btWin32_OnBoardDevice;
        private System.Windows.Forms.Button btWin32_PhysicalMemory;
        private System.Windows.Forms.Button btWin32_Printer;
        private System.Windows.Forms.Button btWin32_MotherboardDevice;
        private System.Windows.Forms.Button btWin32_Processor;
        private System.Windows.Forms.Button btWin32_StartupCommand;
        private System.Windows.Forms.Button btWin32_NetworkAdapter;
        private System.Windows.Forms.Button btWin32_Battery;
        private System.Windows.Forms.Button btWin32_ParallelPort;
        private System.Windows.Forms.Button btWin32_NetworkAdapterConfiguration;
        private System.Windows.Forms.Button btWin32_PortConnector;
        private System.Windows.Forms.Button btWin32_PortResource;
        private System.Windows.Forms.Button btWin32_PortableBattery;
        private System.Windows.Forms.Button btWin32_Product;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

