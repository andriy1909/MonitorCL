namespace MonitorCLServer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("User1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("User2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("User3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("login");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Установленные программы");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Операционная система");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Общая информация");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Пользователи");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Компьютер", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Процессор");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Системная плата");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Память");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("BIOS");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Системная плата", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Операционная система");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Процессы");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Системные драйвера");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Время работы");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Операционная система", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Монитор");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Графический процессор");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Отображение", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Мультимедиа");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Логические диски");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Физические диски");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Оптические накопители");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("ATA");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("SMART");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Хранение данных", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Сеть Windows");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Интернет");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Сеть", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Устройства Windows");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Ввод");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Принтеры");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Устройства", new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode34,
            treeNode35});
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Автозагрузка");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Запланированые");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Установленные программы");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Типы файлов");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Программы", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Региональные установки");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Конфигурация", new System.Windows.Forms.TreeNode[] {
            treeNode42});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgsStatus = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvClients = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.подключитсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.питаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзСистемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезапуститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьПодробнуюИнформациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.cmsNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingAppToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // settingAppToolStripMenuItem
            // 
            this.settingAppToolStripMenuItem.Name = "settingAppToolStripMenuItem";
            this.settingAppToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.settingAppToolStripMenuItem.Text = "SettingApp";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // imgsStatus
            // 
            this.imgsStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgsStatus.ImageStream")));
            this.imgsStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgsStatus.Images.SetKeyName(0, "greyball_2699.png");
            this.imgsStatus.Images.SetKeyName(1, "greenball_5520.png");
            this.imgsStatus.Images.SetKeyName(2, "orangeball_8491.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvClients);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(865, 611);
            this.splitContainer1.SplitterDistance = 152;
            this.splitContainer1.TabIndex = 6;
            // 
            // tvClients
            // 
            this.tvClients.AllowDrop = true;
            this.tvClients.ContextMenuStrip = this.contextMenuStrip1;
            this.tvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvClients.Location = new System.Drawing.Point(0, 25);
            this.tvClients.Name = "tvClients";
            treeNode1.Name = "Узел0";
            treeNode1.Text = "User1";
            treeNode2.Name = "Узел1";
            treeNode2.Text = "User2";
            treeNode3.Name = "Узел2";
            treeNode3.Text = "User3";
            treeNode4.Name = "Узел3";
            treeNode4.Text = "login";
            this.tvClients.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.tvClients.Size = new System.Drawing.Size(152, 586);
            this.tvClients.TabIndex = 8;
            this.tvClients.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvClients_ItemDrag);
            this.tvClients.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvClients_AfterSelect);
            this.tvClients.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvClients_DragDrop);
            this.tvClients.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvClients_DragEnter);
            this.tvClients.DragOver += new System.Windows.Forms.DragEventHandler(this.tvClients_DragOver);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитсяToolStripMenuItem,
            this.питаниеToolStripMenuItem,
            this.показатьПодробнуюИнформациюToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(271, 70);
            // 
            // подключитсяToolStripMenuItem
            // 
            this.подключитсяToolStripMenuItem.Name = "подключитсяToolStripMenuItem";
            this.подключитсяToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.подключитсяToolStripMenuItem.Text = "Подключится";
            this.подключитсяToolStripMenuItem.Click += new System.EventHandler(this.подключитсяToolStripMenuItem_Click);
            // 
            // питаниеToolStripMenuItem
            // 
            this.питаниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиИзСистемыToolStripMenuItem,
            this.выключитьToolStripMenuItem,
            this.перезапуститьToolStripMenuItem});
            this.питаниеToolStripMenuItem.Name = "питаниеToolStripMenuItem";
            this.питаниеToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.питаниеToolStripMenuItem.Text = "Питание";
            // 
            // выйтиИзСистемыToolStripMenuItem
            // 
            this.выйтиИзСистемыToolStripMenuItem.Name = "выйтиИзСистемыToolStripMenuItem";
            this.выйтиИзСистемыToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.выйтиИзСистемыToolStripMenuItem.Text = "Выйти из системы";
            this.выйтиИзСистемыToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзСистемыToolStripMenuItem_Click);
            // 
            // выключитьToolStripMenuItem
            // 
            this.выключитьToolStripMenuItem.Name = "выключитьToolStripMenuItem";
            this.выключитьToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.выключитьToolStripMenuItem.Text = "Выключить";
            this.выключитьToolStripMenuItem.Click += new System.EventHandler(this.выключитьToolStripMenuItem_Click);
            // 
            // перезапуститьToolStripMenuItem
            // 
            this.перезапуститьToolStripMenuItem.Name = "перезапуститьToolStripMenuItem";
            this.перезапуститьToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.перезапуститьToolStripMenuItem.Text = "Перезапустить";
            this.перезапуститьToolStripMenuItem.Click += new System.EventHandler(this.перезапуститьToolStripMenuItem_Click);
            // 
            // показатьПодробнуюИнформациюToolStripMenuItem
            // 
            this.показатьПодробнуюИнформациюToolStripMenuItem.Name = "показатьПодробнуюИнформациюToolStripMenuItem";
            this.показатьПодробнуюИнформациюToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.показатьПодробнуюИнформациюToolStripMenuItem.Text = "Показать подробную информацию";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(152, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "+";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "./";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Х";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(172, 39);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(537, 572);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Свойство";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Значение";
            this.Column2.Name = "Column2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(172, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 39);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(519, 394);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView2);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 611);
            this.panel1.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Indent = 18;
            this.treeView2.ItemHeight = 20;
            this.treeView2.Location = new System.Drawing.Point(0, 25);
            this.treeView2.Name = "treeView2";
            treeNode5.Name = "tnPrograms";
            treeNode5.Text = "Установленные программы";
            treeNode6.Name = "tnOS";
            treeNode6.Text = "Операционная система";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.treeView2.ShowLines = false;
            this.treeView2.Size = new System.Drawing.Size(172, 586);
            this.treeView2.TabIndex = 2;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView2_MouseClick);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Indent = 18;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "Узел9";
            treeNode7.Text = "Общая информация";
            treeNode8.Name = "tnUsers";
            treeNode8.Text = "Пользователи";
            treeNode9.Name = "Узел0";
            treeNode9.Text = "Компьютер";
            treeNode10.Name = "Узел13";
            treeNode10.Text = "Процессор";
            treeNode11.Name = "Узел14";
            treeNode11.Text = "Системная плата";
            treeNode12.Name = "Узел15";
            treeNode12.Text = "Память";
            treeNode13.Name = "Узел16";
            treeNode13.Text = "BIOS";
            treeNode14.Name = "Узел1";
            treeNode14.Text = "Системная плата";
            treeNode15.Name = "tnOS";
            treeNode15.Text = "Операционная система";
            treeNode16.Name = "Узел19";
            treeNode16.Text = "Процессы";
            treeNode17.Name = "Узел20";
            treeNode17.Text = "Системные драйвера";
            treeNode18.Name = "Узел21";
            treeNode18.Text = "Время работы";
            treeNode19.Name = "Узел2";
            treeNode19.Text = "Операционная система";
            treeNode20.Name = "Узел22";
            treeNode20.Text = "Монитор";
            treeNode21.Name = "Узел24";
            treeNode21.Text = "Графический процессор";
            treeNode22.Name = "Узел3";
            treeNode22.Text = "Отображение";
            treeNode23.Name = "Узел4";
            treeNode23.Text = "Мультимедиа";
            treeNode24.Name = "Узел26";
            treeNode24.Text = "Логические диски";
            treeNode25.Name = "Узел27";
            treeNode25.Text = "Физические диски";
            treeNode26.Name = "Узел28";
            treeNode26.Text = "Оптические накопители";
            treeNode27.Name = "Узел31";
            treeNode27.Text = "ATA";
            treeNode28.Name = "Узел30";
            treeNode28.Text = "SMART";
            treeNode29.Name = "Узел5";
            treeNode29.Text = "Хранение данных";
            treeNode30.Name = "Узел32";
            treeNode30.Text = "Сеть Windows";
            treeNode31.Name = "Узел33";
            treeNode31.Text = "Интернет";
            treeNode32.Name = "Узел6";
            treeNode32.Text = "Сеть";
            treeNode33.Name = "Узел37";
            treeNode33.Text = "Устройства Windows";
            treeNode34.Name = "Узел38";
            treeNode34.Text = "Ввод";
            treeNode35.Name = "Узел39";
            treeNode35.Text = "Принтеры";
            treeNode36.Name = "Узел7";
            treeNode36.Text = "Устройства";
            treeNode37.Name = "Узел41";
            treeNode37.Text = "Автозагрузка";
            treeNode38.Name = "Узел42";
            treeNode38.Text = "Запланированые";
            treeNode39.Name = "tnPrograms";
            treeNode39.Text = "Установленные программы";
            treeNode40.Name = "Узел44";
            treeNode40.Text = "Типы файлов";
            treeNode41.Name = "Узел8";
            treeNode41.Text = "Программы";
            treeNode42.Name = "Узел46";
            treeNode42.Text = "Региональные установки";
            treeNode43.Name = "Узел45";
            treeNode43.Text = "Конфигурация";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode14,
            treeNode19,
            treeNode22,
            treeNode23,
            treeNode29,
            treeNode32,
            treeNode36,
            treeNode41,
            treeNode43});
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(172, 586);
            this.treeView1.TabIndex = 1;
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(172, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Visible = false;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 150;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel1.Text = "     ";
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsMain.Size = new System.Drawing.Size(150, 70);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.loginToolStripMenuItem.Text = "Войти";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem1.Text = "О программе";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem1.Text = "Выход";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.stopToolStripMenuItem1,
            this.restartToolStripMenuItem1,
            this.startToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem2});
            this.cmsNotify.Name = "cmsNotify";
            this.cmsNotify.Size = new System.Drawing.Size(197, 126);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openToolStripMenuItem.Text = "Открить";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.stopToolStripMenuItem1.Text = "Остановить сервер";
            this.stopToolStripMenuItem1.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem1
            // 
            this.restartToolStripMenuItem1.Name = "restartToolStripMenuItem1";
            this.restartToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.restartToolStripMenuItem1.Text = "Перезапустить сервер";
            this.restartToolStripMenuItem1.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.startToolStripMenuItem1.Text = "Запустить сервер";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(196, 22);
            this.exitToolStripMenuItem2.Text = "Выход";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 657);
            this.ContextMenuStrip = this.cmsMain;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorCLServer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsMain.ResumeLayout(false);
            this.cmsNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingAppToolStripMenuItem;
        private System.Windows.Forms.ImageList imgsStatus;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.TreeView tvClients;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem подключитсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem питаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выключитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перезапуститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьПодробнуюИнформациюToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзСистемыToolStripMenuItem;
    }
}

