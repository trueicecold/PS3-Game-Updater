using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace PS3GameDetector
{
    class Utils
    {
        /// <summary>
        /// Function to convert the given bytes to either Kilobyte, Megabyte, or Gigabyte
        /// </summary>
        /// <param name="bytes">Double -> Total bytes to be converted</param>
        /// <param name="type">String -> Type of conversion to perform</param>
        /// <returns>Int32 -> Converted bytes</returns>
        /// <remarks></remarks>
        public static string ConvertSize(double bytes, string type)
        {
            double calcBytes;
            string typeStr;
            try
            {
                if (bytes < 1024)
                {
                    type = "BY";
                    typeStr = " b";
                }
                else if (bytes < 1024 * 1024)
                {
                    type = "KB";
                    typeStr = " KB";
                }
                else if (bytes < 1024 * 1024 * 1024)
                {
                    type = "MB";
                    typeStr = " MB";
                }
                else
                {
                    type = "GB";
                    typeStr = " GB";
                }

                const int CONVERSION_VALUE = 1024;
                //determine what conversion they want
                switch (type)
                {
                    case "BY":
                        //convert to bytes (default)
                        calcBytes = bytes;
                        break;
                    case "KB":
                        //convert to kilobytes
                        calcBytes = Math.Round(bytes / CONVERSION_VALUE, 2);
                        break;
                    case "MB":
                        //convert to megabytes
                        calcBytes = Math.Round(bytes / CalculateSquare(CONVERSION_VALUE), 2);
                        break;
                    case "GB":
                        //convert to gigabytes
                        calcBytes = Math.Round(bytes / CalculateCube(CONVERSION_VALUE), 2);
                        break;
                    default:
                        //default
                        calcBytes = bytes;
                        break;
                }
                return Math.Round(calcBytes, 2).ToString() + typeStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "0 b";
            }
        }

        /// <summary>
        /// Function to calculate the square of the provided number
        /// </summary>
        /// <param name="number">Int32 -> Number to be squared</param>
        /// <returns>Double -> THe provided number squared</returns>
        /// <remarks></remarks>
        public static double CalculateSquare(Int32 number)
        {
            return Math.Pow(number, 2);
        }


        /// <summary>
        /// Function to calculate the cube of the provided number
        /// </summary>
        /// <param name="number">Int32 -> Number to be cubed</param>
        /// <returns>Double -> THe provided number cubed</returns>
        /// <remarks></remarks>
        public static double CalculateCube(Int32 number)
        {
            return Math.Pow(number, 3);
        }

        public static string GetValidFileName(string fileName)
        {
            fileName = Regex.Replace(fileName, @"[^\.a-zA-Z0-9 _-]", "");
            return Regex.Replace(fileName, @"[^\u0000-\u007F]", "");
        }

        static FileStream logFile;
        static StreamWriter newLogFile;
        static byte[] messageByteArray;
        static bool isFileDeleted = false;
        public static void Log(string message)
        {
            try
            {
                if (!isFileDeleted && File.Exists(Application.StartupPath + "\\log.txt"))
                {
                    File.Delete(Application.StartupPath + "\\log.txt");
                    isFileDeleted = true;
                }

                if (!File.Exists(Application.StartupPath + "\\log.txt"))
                {
                    newLogFile = File.CreateText(Application.StartupPath + "\\log.txt");
                    newLogFile.WriteLine(message);
                    newLogFile.Close();
                }
                else
                {
                    message = message + Environment.NewLine;
                    logFile = File.Open(Application.StartupPath + "\\log.txt", FileMode.Append);
                    messageByteArray = new System.Text.UTF8Encoding().GetBytes(message);
                    logFile.Write(messageByteArray, 0, messageByteArray.Length);
                    logFile.Close();
                }
            }
            catch(Exception ex)
            {
            }
        }

        static Dictionary<string, int> columnIndexes = new Dictionary<string, int>();
        public static int GetColumnId(string columnName)
        {
            columnIndexes["treeUpdate"] = 0;
            columnIndexes["treeGameDetails"] = 1;
            columnIndexes["treeFWReq"] = 2;
            columnIndexes["treeVersion"] = 3;
            columnIndexes["extCompat"] = 4;
            columnIndexes["treeStatus"] = 5;
            columnIndexes["treePath"] = 6;
            columnIndexes["treeUpdateURL"] = 7;
            columnIndexes["treeUpdateSize"] = 8;
            return columnIndexes[columnName];
        }
    }
}
