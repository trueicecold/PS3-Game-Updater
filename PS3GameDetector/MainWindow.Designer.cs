namespace PS3GameDetector
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportListAsTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGameUpdatesLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pS3FTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchGameIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlSpeedLabel = new System.Windows.Forms.Label();
            this.dlSpeed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.hdPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gameFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ftpPanel = new System.Windows.Forms.Panel();
            this.ftpPath = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ftpCredentials = new System.Windows.Forms.CheckBox();
            this.ftpPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ftpUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ftpHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gameIDPanel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.gameIDSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.treeGridView1 = new AdvancedDataGridView.TreeGridView();
            this.treeUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.treeGameDetails = new AdvancedDataGridView.TreeGridColumn();
            this.treeFWReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extCompat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeUpdateURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeUpdateSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageStrip = new System.Windows.Forms.ImageList(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selectAllUpdates = new System.Windows.Forms.CheckBox();
            this.expandAll = new System.Windows.Forms.Button();
            this.collapseAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.hdPanel.SuspendLayout();
            this.ftpPanel.SuspendLayout();
            this.gameIDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Found Games:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 465);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 42);
            this.button3.TabIndex = 6;
            this.button3.Text = "Check updates for selected games";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importFromToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1098, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exportListAsTextFileToolStripMenuItem,
            this.exportGameUpdatesLinksToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exportListAsTextFileToolStripMenuItem
            // 
            this.exportListAsTextFileToolStripMenuItem.Name = "exportListAsTextFileToolStripMenuItem";
            this.exportListAsTextFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.exportListAsTextFileToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.exportListAsTextFileToolStripMenuItem.Text = "Export list as CSV file";
            this.exportListAsTextFileToolStripMenuItem.Click += new System.EventHandler(this.exportListAsTextFileToolStripMenuItem_Click);
            // 
            // exportGameUpdatesLinksToolStripMenuItem
            // 
            this.exportGameUpdatesLinksToolStripMenuItem.Name = "exportGameUpdatesLinksToolStripMenuItem";
            this.exportGameUpdatesLinksToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.exportGameUpdatesLinksToolStripMenuItem.Text = "Export game updates links";
            this.exportGameUpdatesLinksToolStripMenuItem.Click += new System.EventHandler(this.exportGameUpdatesLinksToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(251, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // importFromToolStripMenuItem
            // 
            this.importFromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hardDriveToolStripMenuItem,
            this.pS3FTPToolStripMenuItem,
            this.searchGameIDToolStripMenuItem});
            this.importFromToolStripMenuItem.Name = "importFromToolStripMenuItem";
            this.importFromToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.importFromToolStripMenuItem.Text = "Import From";
            // 
            // hardDriveToolStripMenuItem
            // 
            this.hardDriveToolStripMenuItem.Checked = true;
            this.hardDriveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hardDriveToolStripMenuItem.Name = "hardDriveToolStripMenuItem";
            this.hardDriveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.hardDriveToolStripMenuItem.Text = "Hard Drive";
            this.hardDriveToolStripMenuItem.Click += new System.EventHandler(this.hardDriveToolStripMenuItem_Click);
            // 
            // pS3FTPToolStripMenuItem
            // 
            this.pS3FTPToolStripMenuItem.Name = "pS3FTPToolStripMenuItem";
            this.pS3FTPToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pS3FTPToolStripMenuItem.Text = "PS3 FTP";
            this.pS3FTPToolStripMenuItem.Click += new System.EventHandler(this.pS3FTPToolStripMenuItem_Click);
            // 
            // searchGameIDToolStripMenuItem
            // 
            this.searchGameIDToolStripMenuItem.Name = "searchGameIDToolStripMenuItem";
            this.searchGameIDToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.searchGameIDToolStripMenuItem.Text = "Search Game ID";
            this.searchGameIDToolStripMenuItem.Click += new System.EventHandler(this.searchGameIDToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // dlSpeedLabel
            // 
            this.dlSpeedLabel.AutoSize = true;
            this.dlSpeedLabel.Location = new System.Drawing.Point(249, 480);
            this.dlSpeedLabel.Name = "dlSpeedLabel";
            this.dlSpeedLabel.Size = new System.Drawing.Size(92, 13);
            this.dlSpeedLabel.TabIndex = 8;
            this.dlSpeedLabel.Text = "Download Speed:";
            // 
            // dlSpeed
            // 
            this.dlSpeed.AutoSize = true;
            this.dlSpeed.Location = new System.Drawing.Point(341, 480);
            this.dlSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.dlSpeed.Name = "dlSpeed";
            this.dlSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dlSpeed.Size = new System.Drawing.Size(0, 13);
            this.dlSpeed.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hdPanel
            // 
            this.hdPanel.Controls.Add(this.button2);
            this.hdPanel.Controls.Add(this.button1);
            this.hdPanel.Controls.Add(this.gameFolderPath);
            this.hdPanel.Controls.Add(this.label1);
            this.hdPanel.Location = new System.Drawing.Point(13, 23);
            this.hdPanel.Name = "hdPanel";
            this.hdPanel.Size = new System.Drawing.Size(1068, 32);
            this.hdPanel.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Get Games List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameFolderPath
            // 
            this.gameFolderPath.Location = new System.Drawing.Point(95, 9);
            this.gameFolderPath.Name = "gameFolderPath";
            this.gameFolderPath.ReadOnly = true;
            this.gameFolderPath.Size = new System.Drawing.Size(274, 20);
            this.gameFolderPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Games Directory:";
            // 
            // ftpPanel
            // 
            this.ftpPanel.Controls.Add(this.ftpPath);
            this.ftpPanel.Controls.Add(this.label6);
            this.ftpPanel.Controls.Add(this.ftpCredentials);
            this.ftpPanel.Controls.Add(this.ftpPassword);
            this.ftpPanel.Controls.Add(this.label5);
            this.ftpPanel.Controls.Add(this.ftpUsername);
            this.ftpPanel.Controls.Add(this.label4);
            this.ftpPanel.Controls.Add(this.button4);
            this.ftpPanel.Controls.Add(this.ftpHost);
            this.ftpPanel.Controls.Add(this.label3);
            this.ftpPanel.Location = new System.Drawing.Point(13, 23);
            this.ftpPanel.Name = "ftpPanel";
            this.ftpPanel.Size = new System.Drawing.Size(1068, 32);
            this.ftpPanel.TabIndex = 13;
            this.ftpPanel.Visible = false;
            // 
            // ftpPath
            // 
            this.ftpPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ftpPath.FormattingEnabled = true;
            this.ftpPath.Location = new System.Drawing.Point(546, 9);
            this.ftpPath.Name = "ftpPath";
            this.ftpPath.Size = new System.Drawing.Size(201, 21);
            this.ftpPath.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(512, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Path:";
            // 
            // ftpCredentials
            // 
            this.ftpCredentials.AutoSize = true;
            this.ftpCredentials.Location = new System.Drawing.Point(167, 13);
            this.ftpCredentials.Name = "ftpCredentials";
            this.ftpCredentials.Size = new System.Drawing.Size(15, 14);
            this.ftpCredentials.TabIndex = 12;
            this.ftpCredentials.UseVisualStyleBackColor = true;
            this.ftpCredentials.CheckedChanged += new System.EventHandler(this.ftpCredentials_CheckedChanged);
            // 
            // ftpPassword
            // 
            this.ftpPassword.Enabled = false;
            this.ftpPassword.Location = new System.Drawing.Point(406, 9);
            this.ftpPassword.Name = "ftpPassword";
            this.ftpPassword.Size = new System.Drawing.Size(100, 20);
            this.ftpPassword.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password:";
            // 
            // ftpUsername
            // 
            this.ftpUsername.Enabled = false;
            this.ftpUsername.Location = new System.Drawing.Point(239, 9);
            this.ftpUsername.Name = "ftpUsername";
            this.ftpUsername.Size = new System.Drawing.Size(100, 20);
            this.ftpUsername.TabIndex = 9;
            this.ftpUsername.Text = "Anonymous";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Username:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(753, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Get Games List";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ftpHost
            // 
            this.ftpHost.Location = new System.Drawing.Point(62, 9);
            this.ftpHost.Name = "ftpHost";
            this.ftpHost.Size = new System.Drawing.Size(100, 20);
            this.ftpHost.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "FTP Host:";
            // 
            // gameIDPanel
            // 
            this.gameIDPanel.Controls.Add(this.button5);
            this.gameIDPanel.Controls.Add(this.gameIDSearch);
            this.gameIDPanel.Controls.Add(this.label10);
            this.gameIDPanel.Location = new System.Drawing.Point(13, 23);
            this.gameIDPanel.Name = "gameIDPanel";
            this.gameIDPanel.Size = new System.Drawing.Size(1068, 32);
            this.gameIDPanel.TabIndex = 16;
            this.gameIDPanel.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(168, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Get Updates";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // gameIDSearch
            // 
            this.gameIDSearch.Location = new System.Drawing.Point(62, 9);
            this.gameIDSearch.Name = "gameIDSearch";
            this.gameIDSearch.Size = new System.Drawing.Size(100, 20);
            this.gameIDSearch.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Game ID:";
            // 
            // treeGridView1
            // 
            this.treeGridView1.AllowUserToAddRows = false;
            this.treeGridView1.AllowUserToDeleteRows = false;
            this.treeGridView1.AllowUserToResizeColumns = false;
            this.treeGridView1.AllowUserToResizeRows = false;
            this.treeGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.treeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.treeUpdate,
            this.treeGameDetails,
            this.treeFWReq,
            this.treeVersion,
            this.extCompat,
            this.treeStatus,
            this.treePath,
            this.treeUpdateURL,
            this.treeUpdateSize});
            this.treeGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGridView1.ImageList = null;
            this.treeGridView1.Location = new System.Drawing.Point(17, 79);
            this.treeGridView1.MultiSelect = false;
            this.treeGridView1.Name = "treeGridView1";
            this.treeGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.treeGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.treeGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.treeGridView1.Size = new System.Drawing.Size(1064, 380);
            this.treeGridView1.TabIndex = 17;
            this.treeGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.treeGridView1_CellClick);
            this.treeGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.treeGridView1_DataError);
            // 
            // treeUpdate
            // 
            this.treeUpdate.HeaderText = "";
            this.treeUpdate.Name = "treeUpdate";
            this.treeUpdate.Width = 30;
            // 
            // treeGameDetails
            // 
            this.treeGameDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.treeGameDetails.DefaultNodeImage = null;
            this.treeGameDetails.FillWeight = 1F;
            this.treeGameDetails.HeaderText = "Game Details";
            this.treeGameDetails.Name = "treeGameDetails";
            this.treeGameDetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.treeGameDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // treeFWReq
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.treeFWReq.DefaultCellStyle = dataGridViewCellStyle1;
            this.treeFWReq.HeaderText = "FW Req.";
            this.treeFWReq.Name = "treeFWReq";
            this.treeFWReq.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.treeFWReq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.treeFWReq.Width = 75;
            // 
            // treeVersion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.treeVersion.DefaultCellStyle = dataGridViewCellStyle2;
            this.treeVersion.HeaderText = "Version";
            this.treeVersion.Name = "treeVersion";
            this.treeVersion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.treeVersion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.treeVersion.Width = 65;
            // 
            // extCompat
            // 
            this.extCompat.HeaderText = "Ext. HDD";
            this.extCompat.Name = "extCompat";
            this.extCompat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.extCompat.Width = 80;
            // 
            // treeStatus
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.treeStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.treeStatus.HeaderText = "Status";
            this.treeStatus.Name = "treeStatus";
            this.treeStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.treeStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.treeStatus.Width = 120;
            // 
            // treePath
            // 
            this.treePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.treePath.FillWeight = 1F;
            this.treePath.HeaderText = "Path";
            this.treePath.Name = "treePath";
            this.treePath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.treePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // treeUpdateURL
            // 
            this.treeUpdateURL.HeaderText = "treeUpdateURL";
            this.treeUpdateURL.Name = "treeUpdateURL";
            this.treeUpdateURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.treeUpdateURL.Visible = false;
            // 
            // treeUpdateSize
            // 
            this.treeUpdateSize.HeaderText = "treeUpdateSize";
            this.treeUpdateSize.Name = "treeUpdateSize";
            this.treeUpdateSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.treeUpdateSize.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItem1.Text = "Copy link to clipboard";
            // 
            // imageStrip
            // 
            this.imageStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // selectAllUpdates
            // 
            this.selectAllUpdates.AutoSize = true;
            this.selectAllUpdates.Checked = true;
            this.selectAllUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectAllUpdates.Location = new System.Drawing.Point(26, 84);
            this.selectAllUpdates.Name = "selectAllUpdates";
            this.selectAllUpdates.Size = new System.Drawing.Size(15, 14);
            this.selectAllUpdates.TabIndex = 18;
            this.selectAllUpdates.UseVisualStyleBackColor = true;
            // 
            // expandAll
            // 
            this.expandAll.Location = new System.Drawing.Point(928, 465);
            this.expandAll.Name = "expandAll";
            this.expandAll.Size = new System.Drawing.Size(75, 23);
            this.expandAll.TabIndex = 19;
            this.expandAll.Text = "Expand All";
            this.expandAll.UseVisualStyleBackColor = true;
            this.expandAll.Click += new System.EventHandler(this.expandAll_Click);
            // 
            // collapseAll
            // 
            this.collapseAll.Location = new System.Drawing.Point(1006, 465);
            this.collapseAll.Name = "collapseAll";
            this.collapseAll.Size = new System.Drawing.Size(75, 23);
            this.collapseAll.TabIndex = 20;
            this.collapseAll.Text = "Collapse All";
            this.collapseAll.UseVisualStyleBackColor = true;
            this.collapseAll.Click += new System.EventHandler(this.collapseAll_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 512);
            this.Controls.Add(this.collapseAll);
            this.Controls.Add(this.expandAll);
            this.Controls.Add(this.selectAllUpdates);
            this.Controls.Add(this.treeGridView1);
            this.Controls.Add(this.gameIDPanel);
            this.Controls.Add(this.ftpPanel);
            this.Controls.Add(this.hdPanel);
            this.Controls.Add(this.dlSpeed);
            this.Controls.Add(this.dlSpeedLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "PS3 Game Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.hdPanel.ResumeLayout(false);
            this.hdPanel.PerformLayout();
            this.ftpPanel.ResumeLayout(false);
            this.ftpPanel.PerformLayout();
            this.gameIDPanel.ResumeLayout(false);
            this.gameIDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Label dlSpeedLabel;
        private System.Windows.Forms.Label dlSpeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem exportListAsTextFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel hdPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox gameFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem importFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pS3FTPToolStripMenuItem;
        private System.Windows.Forms.Panel ftpPanel;
        public System.Windows.Forms.TextBox ftpPassword;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox ftpUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox ftpHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ftpCredentials;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox ftpPath;
        private System.Windows.Forms.Panel gameIDPanel;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox gameIDSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem searchGameIDToolStripMenuItem;
        public AdvancedDataGridView.TreeGridView treeGridView1;
        private System.Windows.Forms.ImageList imageStrip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.CheckBox selectAllUpdates;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn treeUpdate;
        private AdvancedDataGridView.TreeGridColumn treeGameDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeFWReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn extCompat;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn treePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeUpdateURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeUpdateSize;
        private System.Windows.Forms.ToolStripMenuItem exportGameUpdatesLinksToolStripMenuItem;
        private System.Windows.Forms.Button expandAll;
        private System.Windows.Forms.Button collapseAll;
    }
}

