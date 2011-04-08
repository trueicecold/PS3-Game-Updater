using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PS3GameDetector
{
    public partial class FTPImportWindow : Form
    {
        public FTPImportWindow()
        {
            InitializeComponent();
            IOManager.FTPMessage += new IOManager.FTPMessageSent(FtpManager_FTPMessage);
        }

        void FtpManager_FTPMessage(FTPData ftpData)
        {
            ftpStatus.Text = ftpData.Message;
            if (ftpData.Type == 2)
            {
                timer1.Stop();
                progressBar1.Visible = false;
                button1.Text = "Close";
            }
            else
            {
                progressBar1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            IOManager.StopFTPConnection();
            this.Hide();
        }

        public void Start(MainWindow MainForm)
        {
            button1.Text = "Cancel";
            timer1.Start();
            IOManager.GetSFOList(MainForm.ftpHost.Text, MainForm.ftpUsername.Text, MainForm.ftpPassword.Text, MainForm.ftpPath.SelectedItem.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ftpStatus.Text = IOManager.ftpStage;
        }
    }
}
