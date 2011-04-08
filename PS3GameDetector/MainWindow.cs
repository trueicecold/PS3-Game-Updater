using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using SFOReaderSharp;
using System.Xml;
using System.IO;
using AdvancedDataGridView;

namespace PS3GameDetector
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult gameFolderResult = folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
                gameFolderPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;
        private void Form1_Load(object sender, EventArgs e)
        {
            Config.Init();
            IOManager.Init(this);

            WebManager.MainForm = this;
            WebManager.downloadProgress += new WebManager.WebDownloadProgress(WebManager_downloadProgress);
            WebManager.downloadComplete += new WebManager.WebDownloadComplete(WebManager_downloadComplete);

            selectAllUpdates.CheckedChanged += new System.EventHandler(this.selectAllUpdates_CheckedChanged);

            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            if (Config.Get("SaveLastDirectory") == "1" && Config.Get("LastDirectory") != "")
                folderBrowserDialog1.SelectedPath = gameFolderPath.Text = Config.Get("LastDirectory");
            if (Config.Get("FTPHost").Trim() != "")
                ftpHost.Text = Config.Get("FTPHost");
            if (Config.Get("FTPAnonymous").Trim() == "0")
                ftpCredentials.Checked = true;
            if (Config.Get("FTPUsername").Trim() != "")
                ftpUsername.Text = Config.Get("FTPUsername");
            if (Config.Get("FTPPassword").Trim() != "")
                ftpPassword.Text = Config.Get("FTPPassword");
            if (Config.Get("FTPLocations") != "")
            {
                string[] ftpLocations;
                ftpLocations = Config.Get("FTPLocations").Split(',');
                for (int i = 0; i < ftpLocations.Length; i++)
                {
                    ftpPath.Items.Add(ftpLocations[i]);
                    if (Config.Get("FTPPath") != "" && ftpLocations[i] == Config.Get("FTPPath"))
                        ftpPath.SelectedIndex = i;
                    else
                        ftpPath.SelectedIndex = 0;
                }
            }

            imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            imageStrip.TransparentColor = System.Drawing.ColorTranslator.FromHtml("#f000ff");
            imageStrip.ImageSize = new Size(16, 16);
            imageStrip.Images.AddStrip(Properties.Resources.gridImageStrip);
            treeGridView1.ImageList = imageStrip;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gameFolderPath.Text == "")
            {
                MessageBox.Show("Please choose a game folder.");
            }
            else
            {
                treeGridView1.Nodes.Clear();
                if (Config.Get("SaveLastDirectory") == "1")
                    Config.Set("LastDirectory", gameFolderPath.Text);
                IOManager.GetSFOList(gameFolderPath.Text, true);
                for (int i = 0; i < treeGridView1.Nodes.Count; i++)
                {
                    if (treeGridView1.Nodes[i].Level == 1)
                    {
                        string[] gameDetails = treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                        UpdateFinder updateFinder = new UpdateFinder(this);
                        updateFinder.GetUpdates(gameDetails[0]);
                    }
                }
                IOManager.fat32Scanner.StartScan();
            }
        }

        XmlDocument xmlParser = new XmlDocument();
        private string updateFileName;
        private string updateFileSize;
        private int currentNode;
        private int currentSubNode;
        private void checkUpdate()
        {
            for (int i=0; i<treeGridView1.Nodes[currentNode].Cells.Count; i++)
            {
                treeGridView1.Nodes[currentNode].Cells[i].Style.BackColor = treeGridView1.Nodes[currentNode].Cells[i].Style.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#dddddd");
            }

            string target = Application.StartupPath + "\\PS3 Game Updater Updates";
            if (hdPanel.Visible)
            {
                if (Config.Get("SaveUpdatesIn") == "Respective")
                    target = treeGridView1.Nodes[currentNode].Cells[Utils.GetColumnId("treePath")].Value.ToString() + "\\PS3 Game Updater Updates";
                else
                    target = this.gameFolderPath.Text + "\\PS3 Game Updater Updates";
            }
            else if (gameIDPanel.Visible)
                target = Application.StartupPath + "\\PS3 Game Updater Updates";
            else if (ftpPanel.Visible)
                target = Application.StartupPath + "\\PS3 Game Updater Updates (FTP Scan)";
            
            oldBytesDownloaded = 0;
            bytesDownloaded = 0;

            if (treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Level == 2 && treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdate")].GetType().ToString() != "System.Windows.Forms.DataGridViewTextBoxCell")
            {
                updateFileSize = treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdateSize")].Value.ToString();
                string[] gameDetails = treeGridView1.Nodes[currentNode].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                if (Config.Get("FilenameFormat") == "NameAndVersion")
                    updateFileName = Utils.GetValidFileName(gameDetails[1] + " - Version " + treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeVersion")].Value.ToString()) + ".pkg";
                else if (Config.Get("FilenameFormat") == "IDAndNameAndVersion")
                    updateFileName = Utils.GetValidFileName(gameDetails[0] + " - " + gameDetails[1] + " - Version " + treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeVersion")].Value.ToString()) + ".pkg";
                else
                    updateFileName = treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdateURL")].Value.ToString().Substring(treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdateURL")].Value.ToString().LastIndexOf("/") + 1);

                if ((bool)treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdate")].Value == true)
                {
                    if (File.Exists(target + "\\" + updateFileName))
                    {
                        FileInfo fileInfo = new FileInfo(target + "\\" + updateFileName);
                        if (fileInfo.Length.ToString() != updateFileSize)
                        {
                            treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Downloading";
                            WebManager.DownloadUpdate(treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdateURL")].Value.ToString(), target, gameDetails[0], gameDetails[1], treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeVersion")].Value.ToString());
                        }
                        else
                        {
                            treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Already Downloaded";
                            DownloadNextUpdate();
                        }
                    }
                    else
                    {
                        treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Downloading";
                        WebManager.DownloadUpdate(treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeUpdateURL")].Value.ToString(), target, gameDetails[0], gameDetails[1], treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeVersion")].Value.ToString());
                    }
                }
                else
                {
                    treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Skipped";
                    DownloadNextUpdate();
                }
            }
            else
            {
                DownloadNextUpdate();
            }
        }

        private long oldBytesDownloaded = 0;
        private long bytesDownloaded = 0;
        void WebManager_downloadProgress(DownloadData downloadData)
        {
            treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Downloading (" + Math.Round((decimal)downloadData.DownloadedBytes / downloadData.TotalBytes * 100) + "%)";
            treeGridView1.Nodes[currentNode].Cells[Utils.GetColumnId("treeStatus")].Value = "D " + (currentSubNode+1) + "/" + treeGridView1.Nodes[currentNode].Nodes.Count + " (" + Math.Round((decimal)downloadData.DownloadedBytes / downloadData.TotalBytes * 100) + "%)";
            bytesDownloaded = downloadData.DownloadedBytes;
        }

        void WebManager_downloadComplete()
        {
            treeGridView1.Nodes[currentNode].Nodes[currentSubNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Done";
            treeGridView1.Nodes[currentNode].Cells[Utils.GetColumnId("treeStatus")].Value = "Done";
            DownloadNextUpdate();
        }

        private void DownloadNextUpdate()
        {
            currentSubNode++;
            if (currentSubNode < treeGridView1.Nodes[currentNode].Nodes.Count)
            {
                checkUpdate();
            }
            else
            {
                for (int i = 0; i < treeGridView1.Nodes[currentNode].Cells.Count; i++)
                {
                    treeGridView1.Nodes[currentNode].Cells[i].Style.BackColor = treeGridView1.Nodes[currentNode].Cells[i].Style.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                }

                currentSubNode = 0;
                currentNode++;
                if (currentNode < treeGridView1.Nodes.Count)
                {
                    checkUpdate();
                }
                else
                {
                    MessageBox.Show("All updates have been downloaded!");
                    if (Config.Get("OpenFolderAfterDownloadingUpdates") == "1")
                    {
                        System.Diagnostics.Process.Start(gameFolderPath.Text);
                    }
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            treeGridView1.Width = this.Width - 49;
            treeGridView1.Height = this.Height - 174;
            button3.Location = new Point(treeGridView1.Left, treeGridView1.Top + treeGridView1.Height + 4);
            dlSpeedLabel.Top = dlSpeed.Top = button3.Top + ((button3.Height - dlSpeedLabel.Height) / 2);
            collapseAll.Location = new Point(this.Width - 108, this.Height - 85);
            expandAll.Location = new Point(this.Width - 186, this.Height - 85);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeGridView1.Nodes.Count > 0)
            {
                currentNode = 0;
                currentSubNode = 0;
                checkUpdate();
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e, FormClosingEventArgs fe)
        {
            if (MessageBox.Show("Are you sure?", "Exit PS3 Game Updater", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(Form1_FormClosing);
                Application.Exit();
            }
        }

        private About aboutWindow = new About();
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutWindow.ShowInTaskbar = false;
            aboutWindow.ShowDialog(this);
        }

        private Settings settingsWindow = new Settings();
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsWindow.ShowInTaskbar = false;
            settingsWindow.StartPosition = FormStartPosition.CenterParent;
            settingsWindow.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bytesDownloaded - oldBytesDownloaded < 1024)
                dlSpeed.Text = Utils.ConvertSize(bytesDownloaded - oldBytesDownloaded, "BY").ToString() + "/Sec";
            else if (bytesDownloaded - oldBytesDownloaded < 1024 * 1024)
                dlSpeed.Text = Utils.ConvertSize(bytesDownloaded - oldBytesDownloaded, "KB").ToString() + "/Sec";
            else
                dlSpeed.Text = Utils.ConvertSize(bytesDownloaded - oldBytesDownloaded, "MB").ToString() + "/Sec";
            oldBytesDownloaded = bytesDownloaded;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            exitToolStripMenuItem_Click(null, null, e);
        }

        private string fileExportString;
        private StreamWriter exportFile;
        string[] gameDetails;
        string csvChar;
        private void exportListAsTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Comma Delimeted File (*.csv)|*.csv|All Files|*.*";
                DialogResult exportFileName = saveFileDialog1.ShowDialog();
                if (exportFileName.ToString() == "OK")
                {
                    csvChar = Config.Get("CSVSeparator");
                    if (csvChar == "")
                        csvChar = ",";
                    if (csvChar == "TAB")
                        csvChar = ((char)9).ToString();

                    fileExportString = "";
                    fileExportString = "Game ID" + csvChar + "Game Name" + csvChar + "FW Required" + csvChar + "Current Version" + csvChar + "Physical Path" + Environment.NewLine;
                    for (int i = 0; i < treeGridView1.Nodes.Count; i++)
                    {
                        gameDetails = treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                        fileExportString += getExportString(gameDetails[0]) + csvChar + getExportString(gameDetails[1]) + csvChar + getExportString(treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeFWReq")].Value.ToString()) + csvChar + getExportString(treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeVersion")].Value.ToString()) + csvChar + getExportString(treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treePath")].Value.ToString()) + Environment.NewLine;
                    }
                    exportFile = File.CreateText(saveFileDialog1.FileName);
                    exportFile.Write(fileExportString);
                    exportFile.Close();
                    exportFile = null;
                    MessageBox.Show("File exported successfully to:\n" + saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                if (exportFile != null)
                    exportFile.Close();
                MessageBox.Show("Error exporting to file: " + ex.Message);
            }
        }

        private string getExportString(string str)
        {
            return "\"" + str.Replace("\"", "\"\"") + "\"";
        }

        private FTPImportWindow ftpImportWindow = new FTPImportWindow();
        private void button4_Click(object sender, EventArgs e)
        {
            if (ftpHost.Text.Trim() == "")
                MessageBox.Show("Enter FTP host adderss.");
            else if (ftpPath.SelectedItem.ToString().Trim() == "")
                MessageBox.Show("Choose FTP directory path.");
            else
            {
                Config.Set("FTPHost", ftpHost.Text.Trim());
                Config.Set("FTPAnonymous", (ftpCredentials.Checked) ? "0" : "1");
                if (ftpCredentials.Checked)
                {
                    Config.Set("FTPUsername", ftpUsername.Text.Trim());
                    Config.Set("FTPPassword", ftpPassword.Text.Trim());
                }
                Config.Set("FTPPath", ftpPath.SelectedItem.ToString().Trim());
                ftpImportWindow.StartPosition = FormStartPosition.CenterParent;
                ftpImportWindow.ShowInTaskbar = false;
                ftpImportWindow.Start(this);
                ftpImportWindow.ShowDialog();
            }
        }

        private void hardDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardDriveToolStripMenuItem.Checked = true;
            pS3FTPToolStripMenuItem.Checked = false;
            searchGameIDToolStripMenuItem.Checked = false;
            hdPanel.Visible = true;
            ftpPanel.Visible = false;
            gameIDPanel.Visible = false;
        }

        private void pS3FTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardDriveToolStripMenuItem.Checked = false;
            pS3FTPToolStripMenuItem.Checked = true;
            searchGameIDToolStripMenuItem.Checked = false;
            hdPanel.Visible = false;
            ftpPanel.Visible = true;
            gameIDPanel.Visible = false;
        }

        private void searchGameIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardDriveToolStripMenuItem.Checked = false;
            pS3FTPToolStripMenuItem.Checked = false;
            searchGameIDToolStripMenuItem.Checked = true;
            hdPanel.Visible = false;
            ftpPanel.Visible = false;
            gameIDPanel.Visible = true;
        }

        private void ftpCredentials_CheckedChanged(object sender, EventArgs e)
        {
            if (ftpCredentials.Checked)
            {
                ftpUsername.Enabled = ftpPassword.Enabled = true;
                ftpUsername.Text = "";
                ftpPassword.Text = "";
            }
            else
            {
                ftpUsername.Enabled = ftpPassword.Enabled = false;
                ftpUsername.Text = "Anonymous";
                ftpPassword.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (gameIDSearch.Text.Trim() != "")
            {
                treeGridView1.Nodes.Clear();
                IOManager.getUpdatesByGameID(gameIDSearch.Text.ToUpper());
            }
            else
            {
                MessageBox.Show("Enter a Game ID.");
            }
        }

        private void treeGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (((TreeGridView)sender).CurrentNode.Cells[Utils.GetColumnId("treeUpdate")].GetType().ToString() != "System.Windows.Forms.DataGridViewTextBoxCell")
                {
                    ((TreeGridView)sender).CurrentNode.Cells[Utils.GetColumnId("treeUpdate")].Value = !(bool)((TreeGridView)sender).CurrentNode.Cells[Utils.GetColumnId("treeUpdate")].Value;
                    if (((TreeGridView)sender).CurrentNode.Level == 1)
                    {
                        for (int i = 0; i < ((TreeGridView)sender).CurrentNode.Nodes.Count; i++)
                        {
                            if (((TreeGridView)sender).CurrentNode.Nodes[i].Cells[Utils.GetColumnId("treeUpdate")].GetType().ToString() != "System.Windows.Forms.DataGridViewTextBoxCell")
                                ((TreeGridView)sender).CurrentNode.Nodes[i].Cells[Utils.GetColumnId("treeUpdate")].Value = ((TreeGridView)sender).CurrentNode.Cells[Utils.GetColumnId("treeUpdate")].Value;
                        }
                    }
                    if (((TreeGridView)sender).CurrentNode.Level == 2)
                    {
                        if (!(bool)((TreeGridView)sender).CurrentNode.Cells[Utils.GetColumnId("treeUpdate")].Value)
                        {
                            ((TreeGridView)sender).CurrentNode.Parent.Cells[Utils.GetColumnId("treeUpdate")].Value = false;
                            selectAllUpdates.CheckedChanged -= new System.EventHandler(this.selectAllUpdates_CheckedChanged);
                            selectAllUpdates.Checked = false;
                            selectAllUpdates.CheckedChanged += new System.EventHandler(this.selectAllUpdates_CheckedChanged);
                        }
                        else
                        {
                            ((TreeGridView)sender).CurrentNode.Parent.Cells[Utils.GetColumnId("treeUpdate")].Value = true;
                            for (int i = 0; i < ((TreeGridView)sender).CurrentNode.Parent.Nodes.Count; i++)
                            {
                                if (!(bool)((TreeGridView)sender).CurrentNode.Parent.Nodes[i].Cells[Utils.GetColumnId("treeUpdate")].Value)
                                {
                                    ((TreeGridView)sender).CurrentNode.Parent.Cells[Utils.GetColumnId("treeUpdate")].Value = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < treeGridView1.Nodes.Count; i++)
            {
                if (!(bool)treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeUpdate")].Value)
                {
                    selectAllUpdates.CheckedChanged -= new System.EventHandler(this.selectAllUpdates_CheckedChanged);
                    selectAllUpdates.Checked = false;
                    selectAllUpdates.CheckedChanged += new System.EventHandler(this.selectAllUpdates_CheckedChanged);
                    return;
                }
                for (int j = 0; j < treeGridView1.Nodes[i].Nodes.Count; j++)
                {
                    if (treeGridView1.Nodes[i].Nodes[j].Cells[Utils.GetColumnId("treeUpdate")].GetType().ToString() != "System.Windows.Forms.DataGridViewTextBoxCell")
                    {
                        if (!(bool)treeGridView1.Nodes[i].Nodes[j].Cells[Utils.GetColumnId("treeUpdate")].Value)
                        {
                            selectAllUpdates.CheckedChanged -= new System.EventHandler(this.selectAllUpdates_CheckedChanged);
                            selectAllUpdates.Checked = false;
                            selectAllUpdates.CheckedChanged += new System.EventHandler(this.selectAllUpdates_CheckedChanged);
                            return;
                        }
                    }
                }
            }
            selectAllUpdates.CheckedChanged -= new System.EventHandler(this.selectAllUpdates_CheckedChanged);
            selectAllUpdates.Checked = true;
            selectAllUpdates.CheckedChanged += new System.EventHandler(this.selectAllUpdates_CheckedChanged);
        }

        private void treeGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void selectAllUpdates_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < treeGridView1.Nodes.Count; i++)
            {
                treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeUpdate")].Value = selectAllUpdates.Checked;
                for (int j = 0; j < treeGridView1.Nodes[i].Nodes.Count; j++)
                {
                    if (treeGridView1.Nodes[i].Nodes[j].Cells[Utils.GetColumnId("treeUpdate")].GetType().ToString() != "System.Windows.Forms.DataGridViewTextBoxCell")
                        treeGridView1.Nodes[i].Nodes[j].Cells[Utils.GetColumnId("treeUpdate")].Value = selectAllUpdates.Checked;
                }
            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CSNQ7NJ9S7E8Y";
            proc.Start();
        }

        private void exportGameUpdatesLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Text File (*.txt)|*.txt|All Files|*.*";
                DialogResult exportFileName = saveFileDialog1.ShowDialog();
                if (exportFileName.ToString() == "OK")
                {
                    fileExportString = "";
                    for (int i = 0; i < treeGridView1.Nodes.Count; i++)
                    {
                        if (treeGridView1.Nodes[i].Nodes.Count > 0 && treeGridView1.Nodes[i].Nodes[0].Cells[Utils.GetColumnId("treeVersion")].Value.ToString() != "")
                        {
                            gameDetails = treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                            for (int j = 0; j < getExportString(gameDetails[1]).Length; j++)
                                fileExportString += "-";
                            fileExportString += "\n";
                            fileExportString += getExportString(gameDetails[1]);
                            fileExportString += "\n";
                            for (int j = 0; j < getExportString(gameDetails[1]).Length; j++)
                                fileExportString += "-";
                            fileExportString += "\n";
                            for (int j = 0; j < treeGridView1.Nodes[i].Nodes.Count; j++)
                            {
                                fileExportString += "Version " + treeGridView1.Nodes[i].Nodes[j].Cells[Utils.GetColumnId("treeVersion")].Value + ": " + treeGridView1.Nodes[i].Nodes[j].Cells[Utils.GetColumnId("treeUpdateURL")].Value + "\n";
                            }
                            fileExportString += "\n";
                        }
                    }
                    exportFile = File.CreateText(saveFileDialog1.FileName);
                    exportFile.Write(fileExportString);
                    exportFile.Close();
                    exportFile = null;
                    MessageBox.Show("Game updates exported successfully to:\n" + saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                if (exportFile != null)
                    exportFile.Close();
                MessageBox.Show("Error exporting to file: " + ex.Message);
            }
        }

        private void expandAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeGridView1.Nodes.Count; i++)
            {
                if (treeGridView1.Nodes[i].Level == 1)
                    treeGridView1.Nodes[i].Expand();
            }
        }

        private void collapseAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeGridView1.Nodes.Count; i++)
            {
                if (treeGridView1.Nodes[i].Level == 1)
                    treeGridView1.Nodes[i].Collapse();
            }
        }        
    }
}
