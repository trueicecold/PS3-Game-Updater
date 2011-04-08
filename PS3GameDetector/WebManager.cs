using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace PS3GameDetector
{
    class WebManager
    {
        public static event WebUpdateData updateData;
        public delegate void WebUpdateData(UpdateData updateData);

        public static event WebUpdateListData updateListData;
        public delegate void WebUpdateListData(UpdateListData updateListData);

        public static event WebDownloadProgress downloadProgress;
        public delegate void WebDownloadProgress(DownloadData downloadData);

        public static event WebDownloadComplete downloadComplete;
        public delegate void WebDownloadComplete();
        
        private static WebClient webClient = new WebClient();
        public static MainWindow MainForm;

        public static void GetUpdate(string gameId)
        {
            string updateResponse = HTTP.GET(Config.RetailURL.Replace("[GAMEID]", gameId));
            updateData(new UpdateData(updateResponse));
        }

        public static void GetUpdateListByGameID(string gameId)
        {
            string updateResponse = HTTP.GET(Config.RetailURL.Replace("[GAMEID]", gameId));
            updateListData(new UpdateListData(updateResponse));
        }

        public static void DownloadUpdate(string url, string target, string gameId, string gameName, string updateVersion)
        {
            webClient.DownloadProgressChanged -= new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadFileCompleted -= new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);
            if (Config.Get("FilenameFormat") == "NameAndVersion")
                webClient.DownloadFileAsync(new Uri(url), target + "\\" + Utils.GetValidFileName(gameName + " - Version " + updateVersion) + ".pkg");
            else if (Config.Get("FilenameFormat") == "IDAndNameAndVersion")
                webClient.DownloadFileAsync(new Uri(url), target + "\\" + Utils.GetValidFileName(gameId + " - " + gameName + " - Version " + updateVersion) + ".pkg");
            else
                webClient.DownloadFileAsync(new Uri(url), target + "\\" + url.Substring(url.LastIndexOf("/") + 1));
        }

        static void  webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            downloadComplete();
        }

        static void  webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("R: " + e.BytesReceived + ", T: " + e.TotalBytesToReceive);
            downloadProgress(new DownloadData(e.BytesReceived, e.TotalBytesToReceive));
        }
    }
}
