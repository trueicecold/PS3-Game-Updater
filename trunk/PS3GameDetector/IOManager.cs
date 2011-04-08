using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using SFOReaderSharp;
using Starksoft.Net.Ftp;
using System.Windows.Forms;
using AdvancedDataGridView;

namespace PS3GameDetector
{
    class IOManager
    {
        static MainWindow MainForm;
        public static Fat32Scanner fat32Scanner;

        public static void Init(MainWindow mainForm)
        {
            MainForm = mainForm;
            WebManager.updateListData += new WebManager.WebUpdateListData(WebManager_updateListData);
            ftpClient.CommandTimeout = 60000;
            ftpClient.TcpTimeout = 60000;
            ftpClient.DataTransferMode = TransferMode.Passive;
            ftpClient.FileTransferType = TransferType.Binary;
            ftpClient.ServerResponse += new EventHandler<FtpResponseEventArgs>(ftpClient_ServerResponse);
            ftpClient.OpenAsyncCompleted += new EventHandler<OpenAsyncCompletedEventArgs>(ftpClient_OpenAsyncCompleted);
            ftpClient.GetFileAsyncCompleted += new EventHandler<GetFileAsyncCompletedEventArgs>(ftpClient_GetFileAsyncCompleted);
            ftpClient.GetDirListAsyncCompleted += new EventHandler<GetDirListAsyncCompletedEventArgs>(ftpClient_GetDirListAsyncCompleted);
            fat32Scanner = new Fat32Scanner(mainForm);
        }

        public static event FTPMessageSent FTPMessage;
        public delegate void FTPMessageSent(FTPData ftpData);
        
        private static SFOReader sfoReader;
        private static Dictionary<string, string> sfoParams;
        
        #region Get SFO List from HDD

        public static void GetSFOList(string path, bool reset)
        {
            string[] files = null;
            string[] directories = null;

            if (reset)
            {
                fat32Scanner.Reset();
            }
            try
            {
                files = System.IO.Directory.GetFiles(path);
                directories = System.IO.Directory.GetDirectories(path);

                foreach (string file in files)
                {
                    if (file.ToLower().IndexOf("param.sfo") > -1)
                    {
                        if (path.Substring(path.LastIndexOf("\\") + 1).ToLower() == "ps3_game")
                        {
                            try
                            {
                                sfoReader = new SFOReader(file);
                                sfoParams = sfoReader.getKeyValueMap();
                                TreeGridNode node;
                                if (sfoParams.ContainsKey("TITLE_ID") && sfoParams.ContainsKey("TITLE") && sfoParams.ContainsKey("VERSION"))
                                {
                                    if (Config.Get("CheckFat32") == "1")
                                    {
                                        Console.WriteLine("Start Scanning");
                                        node = MainForm.treeGridView1.Nodes.Add(true, sfoParams["TITLE_ID"] + " - " + sfoParams["TITLE"], sfoParams["PS3_SYSTEM_VER"], sfoParams["VERSION"], "Scanning...", "Idle", path.Substring(0, path.LastIndexOf("\\")));
                                        fat32Scanner.AddToScan(path, sfoParams["TITLE_ID"]);
                                    }
                                    else
                                    {
                                        node = MainForm.treeGridView1.Nodes.Add(true, sfoParams["TITLE_ID"] + " - " + sfoParams["TITLE"], sfoParams["PS3_SYSTEM_VER"], sfoParams["VERSION"], "Disabled", "Idle", path.Substring(0, path.LastIndexOf("\\")));
                                    }

                                    node.ImageIndex = 0;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }

                foreach (string directory in directories)
                {
                    GetSFOList(directory, false);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
        #region Get SFO List from FTP

        private static FtpClient ftpClient = new FtpClient();
        private static ArrayList ftpSFOList;
        static int sfoPosition;
        static string sfoPath;
        public static string ftpStage;
        public static void GetSFOList(string hostname, string user, string password, string path)
        {
            MainForm.treeGridView1.Nodes.Clear();
            sfoPath = path;
            if (ftpClient.IsConnected)
                ftpClient.Close();
            sfoPosition = 0;
            ftpSFOList = new ArrayList();
            ftpStage = "Logging in to FTP server...";
            FTPMessage(new FTPData(1, "Logging in to FTP server..."));
            ftpClient.Host = hostname;
            ftpClient.OpenAsync(user, password);
        }

        static void ftpClient_OpenAsyncCompleted(object sender, OpenAsyncCompletedEventArgs e)
        {
            if (ftpClient.IsConnected)
            {
                ftpStage = "Scanning Folders...";
                FTPMessage(new FTPData(1, "Scanning Folders..."));
                ftpClient.ChangeDirectory(sfoPath);
                ftpClient.GetDirListAsync();
            }
            else
            {
                FTPMessage(new FTPData(2, "Connection Error." + Environment.NewLine + Environment.NewLine + "Check your PS3 ftp settings."));
            }
        }

        static void ftpClient_GetDirListAsyncCompleted(object sender, GetDirListAsyncCompletedEventArgs e)
        {
            try
            {
                for (int i = e.DirectoryListingResult.Count-1; i > -1; i--)
                {
                    ftpStage = "Scanning Folder:" + Environment.NewLine + Environment.NewLine + e.DirectoryListingResult[i].FullPath;
                    ftpClient.ChangeDirectory(sfoPath + e.DirectoryListingResult[i].FullPath);
                    if (ftpClient.Exists("PS3_GAME"))
                    {
                        ftpClient.ChangeDirectory("PS3_GAME");
                        if (ftpClient.Exists("PARAM.SFO"))
                        {
                            ftpSFOList.Add(sfoPath + e.DirectoryListingResult[i].FullPath);
                        }
                    }
                    else if (ftpClient.Exists("PARAM.SFO"))
                    {
                        ftpSFOList.Add(sfoPath + e.DirectoryListingResult[i].FullPath);
                    }
                }
                downloadFTPSFO();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void downloadFTPSFO()
        {
            ftpStage = "Analyzing Folder:" + Environment.NewLine + Environment.NewLine + ftpSFOList[sfoPosition];
            FTPMessage(new FTPData(1, "Analyzing Folder:" + Environment.NewLine + Environment.NewLine + ftpSFOList[sfoPosition]));
            ftpClient.ChangeDirectory(ftpSFOList[sfoPosition].ToString());
            if (ftpClient.Exists("PS3_GAME"))
                ftpClient.ChangeDirectory("PS3_GAME");
            ftpClient.GetFileAsync("PARAM.SFO", Application.StartupPath + "\\PARAM.SFO", FileAction.Create);
        }

        static void ftpClient_GetFileAsyncCompleted(object sender, GetFileAsyncCompletedEventArgs e)
        {
            sfoReader = new SFOReader(Application.StartupPath + "\\PARAM.SFO");
            sfoParams = sfoReader.getKeyValueMap();

            if (sfoParams.ContainsKey("CATEGORY") && ((ftpClient.CurrentDirectory.IndexOf("PS3_GAME") > -1 && sfoParams["CATEGORY"] == "DG") || (ftpClient.CurrentDirectory.IndexOf("PS3_GAME") == -1 && sfoParams["CATEGORY"] == "HG")))
            {
                if (sfoParams.ContainsKey("TITLE_ID") && sfoParams.ContainsKey("TITLE") && sfoParams.ContainsKey("VERSION"))
                {
                    TreeGridNode node = MainForm.treeGridView1.Nodes.Add(true, sfoParams["TITLE_ID"] + " - " + sfoParams["TITLE"], sfoParams.ContainsKey("PS3_SYSTEM_VER") ? sfoParams["PS3_SYSTEM_VER"] : "-------", sfoParams["VERSION"], "Unavailable", "Idle", ftpSFOList[sfoPosition]);
                    node.ImageIndex = 0;
                    UpdateFinder updateFinder = new UpdateFinder(MainForm);
                    updateFinder.GetUpdates(sfoParams["TITLE_ID"]);
                }
            }
            if (ftpSFOList.Count - 1 > sfoPosition)
            {
                sfoPosition++;
                downloadFTPSFO();
            }
            else
            {
                ftpStage = "FTP Import Done";
                FTPMessage(new FTPData(2, "FTP Import Done"));
                ftpClient.Close();
            }
        }

        static void ftpClient_ServerResponse(object sender, FtpResponseEventArgs e)
        {
            Console.WriteLine(e.Response.Code + ": " + e.Response.Text);
        }

        public static void StopFTPConnection()
        {
            if (ftpClient.IsConnected)
            {
                ftpClient.Abort();
                ftpClient.Close();
            }
        }

        #endregion
        #region Get Updates By Game ID
        private static string searchGameID;
        
        public static void getUpdatesByGameID(string gameID)
        {
            searchGameID = gameID;
            WebManager.GetUpdateListByGameID(gameID);
        }

        static void WebManager_updateListData(UpdateListData updateListData)
        {
            if (updateListData.Status)
            {
                TreeGridNode node = MainForm.treeGridView1.Nodes.Add(true, searchGameID + " - " + updateListData.GameName, "------", "------", "Unavailable", "Idle", "Online Search");
                node.ImageIndex = 0;
                UpdateFinder updateFinder = new UpdateFinder(MainForm);
                updateFinder.GetUpdates(searchGameID);
            }
            else
                MessageBox.Show("No results found.");
        }
        #endregion
    }
}
