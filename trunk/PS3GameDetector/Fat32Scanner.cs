using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace PS3GameDetector
{
    class Fat32Scanner
    {
        string gameId;
        string gamePath;
        bool fat32Compatible = true;
        MainWindow mainWindow;
        BackgroundWorker bgWorker = new BackgroundWorker();

        
        ArrayList gamePaths = new ArrayList();
        ArrayList gameIds = new ArrayList();
        int currentPosition = 0;

        public Fat32Scanner(MainWindow mainForm)
        {
            mainWindow = mainForm;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentPosition++;
            StartScan();
        }

        public void Reset()
        {
            bgWorker.CancelAsync();
            currentPosition = 0;
            gamePaths.Clear();
            gameIds.Clear();
        }

        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            scanFolders();
        }

        public void AddToScan(string path, string GameID)
        {
            gamePaths.Add(path);
            gameIds.Add(GameID);
        }

        public void StartScan()
        {
            if (gameIds.Count > currentPosition)
            {
                fat32Compatible = true;
                gameId = gameIds[currentPosition].ToString();
                gamePath = gamePaths[currentPosition].ToString();
                bgWorker.RunWorkerAsync();
            }
        }

        private FileInfo fileInfo;
        private void scanFolders()
        {
            string[] files = null;
            string[] directories = null;
            try
            {
                files = System.IO.Directory.GetFiles(gamePath);
                directories = System.IO.Directory.GetDirectories(gamePath);

                foreach (string file in files)
                {
                    fileInfo = new FileInfo(file);
                    if ((Convert.ToDouble(fileInfo.Length) / 1024 / 1024 / 1024) > 4)
                    {
                        fat32Compatible = false;
                        break;
                    }
                }

                foreach (string directory in directories)
                {
                    gamePath = directory;
                    scanFolders();
                }

                for (int i = 0; i < mainWindow.treeGridView1.Nodes.Count; i++)
                {
                    if (mainWindow.treeGridView1.Nodes.Count >= i && mainWindow.treeGridView1.Nodes[i].Cells.Count > 5 && mainWindow.treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value != null)
                    {
                        if (mainWindow.treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().IndexOf(gameId) > -1)
                        {
                            mainWindow.treeGridView1.Nodes[i].Cells[Utils.GetColumnId("extCompat")].Value = (fat32Compatible == true) ? "Yes" : "No";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
