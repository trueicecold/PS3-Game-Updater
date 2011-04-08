namespace PS3GameDetector
{
    partial class Settings
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
            this.saveUpdatesIn = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveLastDir = new System.Windows.Forms.CheckBox();
            this.openFolderAfterDownloadingUpdates = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filenameFormat = new System.Windows.Forms.ComboBox();
            this.checkFat32 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.csvSeparator = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // saveUpdatesIn
            // 
            this.saveUpdatesIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saveUpdatesIn.FormattingEnabled = true;
            this.saveUpdatesIn.Items.AddRange(new object[] {
            "Selected folder",
            "Each game folder"});
            this.saveUpdatesIn.Location = new System.Drawing.Point(116, 36);
            this.saveUpdatesIn.Name = "saveUpdatesIn";
            this.saveUpdatesIn.Size = new System.Drawing.Size(156, 21);
            this.saveUpdatesIn.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Close);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Save updates in:";
            // 
            // saveLastDir
            // 
            this.saveLastDir.AutoSize = true;
            this.saveLastDir.Location = new System.Drawing.Point(12, 13);
            this.saveLastDir.Name = "saveLastDir";
            this.saveLastDir.Size = new System.Drawing.Size(139, 17);
            this.saveLastDir.TabIndex = 7;
            this.saveLastDir.Text = "Save last directory used";
            this.saveLastDir.UseVisualStyleBackColor = true;
            // 
            // openFolderAfterDownloadingUpdates
            // 
            this.openFolderAfterDownloadingUpdates.AutoSize = true;
            this.openFolderAfterDownloadingUpdates.Location = new System.Drawing.Point(12, 178);
            this.openFolderAfterDownloadingUpdates.Name = "openFolderAfterDownloadingUpdates";
            this.openFolderAfterDownloadingUpdates.Size = new System.Drawing.Size(209, 17);
            this.openFolderAfterDownloadingUpdates.TabIndex = 8;
            this.openFolderAfterDownloadingUpdates.Text = "Open folder after downloading updates";
            this.openFolderAfterDownloadingUpdates.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Update file name format:";
            // 
            // filenameFormat
            // 
            this.filenameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filenameFormat.FormattingEnabled = true;
            this.filenameFormat.Items.AddRange(new object[] {
            "Original Name",
            "[Game Name] - [Version]",
            "[Game ID] - [Game Name] - [Version]"});
            this.filenameFormat.Location = new System.Drawing.Point(137, 63);
            this.filenameFormat.Name = "filenameFormat";
            this.filenameFormat.Size = new System.Drawing.Size(203, 21);
            this.filenameFormat.TabIndex = 9;
            // 
            // checkFat32
            // 
            this.checkFat32.AutoSize = true;
            this.checkFat32.Location = new System.Drawing.Point(12, 93);
            this.checkFat32.Name = "checkFat32";
            this.checkFat32.Size = new System.Drawing.Size(231, 17);
            this.checkFat32.TabIndex = 11;
            this.checkFat32.Text = "Check for Fat32 compatibility (Experimental)";
            this.checkFat32.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "CSV separator:";
            // 
            // csvSeparator
            // 
            this.csvSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.csvSeparator.FormattingEnabled = true;
            this.csvSeparator.Items.AddRange(new object[] {
            ",",
            ";",
            "TAB"});
            this.csvSeparator.Location = new System.Drawing.Point(116, 116);
            this.csvSeparator.Name = "csvSeparator";
            this.csvSeparator.Size = new System.Drawing.Size(55, 21);
            this.csvSeparator.TabIndex = 12;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 236);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.csvSeparator);
            this.Controls.Add(this.checkFat32);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filenameFormat);
            this.Controls.Add(this.openFolderAfterDownloadingUpdates);
            this.Controls.Add(this.saveLastDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveUpdatesIn);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox saveUpdatesIn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox saveLastDir;
        private System.Windows.Forms.CheckBox openFolderAfterDownloadingUpdates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox filenameFormat;
        private System.Windows.Forms.CheckBox checkFat32;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox csvSeparator;
    }
}