using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PS3GameDetector
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public static class Config
    {
        public static string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        public static string RetailURL = "https://a0.ww.np.dl.playstation.net/tpl/np/[GAMEID]/[GAMEID]-ver.xml";

        public static void Init()
        {
            path = Application.StartupPath + "\\settings.ini";
            if (!File.Exists(path))
            {
                File.WriteAllLines(path, new string[] { "[Settings]" });
                WritePrivateProfileString("Settings", "SaveLastDirectory", "0", path);
                WritePrivateProfileString("Settings", "LastDirectory", "", path);
                WritePrivateProfileString("Settings", "FTPHost", "", path);
                WritePrivateProfileString("Settings", "FTPAnonymous", "", path);
                WritePrivateProfileString("Settings", "FTPUsername", "", path);
                WritePrivateProfileString("Settings", "FTPPassword", "", path);
                WritePrivateProfileString("Settings", "FTPLocations", "/dev_hdd0/GAMEZ,/dev_usb0/GAMES,/dev_hdd0/game/LAUN12345/GAMEZ", path);
                WritePrivateProfileString("Settings", "FilenameFormat", "Original", path);
                WritePrivateProfileString("Settings", "CSVSeparator", ",", path);
            }
        }

        public static void Set(string Key, string Value)
        {
            WritePrivateProfileString("Settings", Key, Value, path);
        }

        public static string Get(string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString("Settings", Key, "", temp,
                                            255, path);
            return temp.ToString();

        }
    }
}