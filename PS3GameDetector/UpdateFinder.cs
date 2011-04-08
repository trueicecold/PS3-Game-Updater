using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using AdvancedDataGridView;
using System.Windows.Forms;
using System.IO;

namespace PS3GameDetector
{
    class UpdateFinder
    {
        private string GameID = "";
        private WebClient updateWebClient = new WebClient();
        private XmlDocument updateParser = new XmlDocument();
        private MainWindow MainForm;
        private XmlNodeList _updateVersions;
        private string updateFWVersion;
        private string updateVersion;
        private string updateURL;
        private double updateSize;

        public UpdateFinder(MainWindow mainForm)
        {
            MainForm = mainForm;
            updateWebClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(updateWebClient_DownloadDataCompleted);
        }

        void updateWebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //Utils.Log("Getting updates for " + GameID + " completed, parsing...");
            try
            {
                if (e.Error == null)
                {
                    updateParser.LoadXml(System.Text.UTF8Encoding.UTF8.GetString(e.Result));
                    //Utils.Log(GameID + " Parsing success");
                    if (updateParser.SelectSingleNode("//titlepatch").Attributes["status"].Value == "alive")
                    {
                        _updateVersions = updateParser.SelectNodes("//titlepatch/tag/package");
                        //Utils.Log(GameID + " Updates found: " + _updateVersions.Count);
                        if (_updateVersions.Count > 0)
                        {
                            for (int i = 0; i < _updateVersions.Count; i++)
                            {
                                updateFWVersion = (_updateVersions[i].Attributes["ps3_system_ver"] != null) ? _updateVersions[i].Attributes["ps3_system_ver"].Value : "Unknown";
                                updateVersion = (_updateVersions[i].Attributes["version"] != null) ? _updateVersions[i].Attributes["version"].Value : "Unknown";
                                updateSize = (_updateVersions[i].Attributes["size"] != null) ? Convert.ToDouble(_updateVersions[i].Attributes["size"].Value) : 0;
                                updateURL = (_updateVersions[i].Attributes["url"] != null) ? _updateVersions[i].Attributes["url"].Value : "";

                                /*
                                Utils.Log(GameID + " Update " + i + ": version=" + updateVersion);
                                Utils.Log(GameID + " Update " + i + ": ps3_ver=" + updateFWVersion);
                                Utils.Log(GameID + " Update " + i + ": size=" + updateSize);
                                Utils.Log(GameID + " Update " + i + ": url=" + updateURL);
                                */

                                for (int j = 0; j < MainForm.treeGridView1.Nodes.Count; j++)
                                {
                                    if (MainForm.treeGridView1.Nodes[j].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().IndexOf(GameID) == 0)
                                    {
                                        TreeGridNode node = MainForm.treeGridView1.Nodes[j].Nodes.Add(true, "Version " + updateVersion + " update (" + Utils.ConvertSize(updateSize, "MB") + ")", updateFWVersion, updateVersion, "", "Idle", "", _updateVersions[i].Attributes["url"].Value, updateSize.ToString());
                                        node.ImageIndex = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < MainForm.treeGridView1.Nodes.Count; i++)
                            {
                                if (MainForm.treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().IndexOf(GameID) == 0)
                                {
                                    TreeGridNode node = MainForm.treeGridView1.Nodes[i].Nodes.Add(false, "No Updates found", "", "", "", "", "");
                                    node.Cells.RemoveAt(0);
                                    node.Cells.Insert(0, new DataGridViewTextBoxCell());
                                    node.Cells[Utils.GetColumnId("treeUpdate")].Value = "";
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < MainForm.treeGridView1.Nodes.Count; i++)
                {
                    if (MainForm.treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().IndexOf(GameID) == 0)
                    {
                        TreeGridNode node = MainForm.treeGridView1.Nodes[i].Nodes.Add(false, "No Updates found", "", "", "", "", "");
                        node.Cells.RemoveAt(0);
                        node.Cells.Insert(0, new DataGridViewTextBoxCell());
                        node.Cells[Utils.GetColumnId("treeUpdate")].Value = "";
                        break;
                    }
                }
            }
        }

        public void GetUpdates(string gameId)
        {
            //Utils.Log("Gettings updates for " + gameId);
            try
            {
                GameID = gameId.Trim();
                if (GameID != "")
                {
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                    updateWebClient.DownloadDataAsync(new Uri(Config.RetailURL.Replace("[GAMEID]", GameID)));
                }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < MainForm.treeGridView1.Nodes.Count; i++)
                {
                    if (MainForm.treeGridView1.Nodes[i].Cells[Utils.GetColumnId("treeGameDetails")].Value.ToString().IndexOf(GameID) == 0)
                    {
                        TreeGridNode node = MainForm.treeGridView1.Nodes[i].Nodes.Add(false, "Error downloading updates", "", "", "", "", "");
                        break;
                    }
                }
                //Utils.Log("Error downloading updates for " + gameId + " (" + ex.Message + ")");
            }
        }

        bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
