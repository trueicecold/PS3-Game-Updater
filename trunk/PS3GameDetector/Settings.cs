using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PS3GameDetector
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveLastDir.Checked)
                Config.Set("SaveLastDirectory", "1");
            else
                Config.Set("SaveLastDirectory", "0");

            if (saveUpdatesIn.SelectedIndex == 0)
                Config.Set("SaveUpdatesIn", "Root");
            else
                Config.Set("SaveUpdatesIn", "Respective");

            if (openFolderAfterDownloadingUpdates.Checked)
                Config.Set("OpenFolderAfterDownloadingUpdates", "1");
            else
                Config.Set("OpenFolderAfterDownloadingUpdates", "0");

            if (filenameFormat.SelectedIndex == 2)
                Config.Set("FilenameFormat", "IDAndNameAndVersion");
            else if (filenameFormat.SelectedIndex == 1)
                Config.Set("FilenameFormat", "NameAndVersion");
            else
                Config.Set("FilenameFormat", "Original");

            if (checkFat32.Checked)
                Config.Set("CheckFat32", "1");
            else
                Config.Set("CheckFat32", "0");
            
            if (csvSeparator.SelectedIndex == 1)
                Config.Set("CSVSeparator", ";");
            else if (csvSeparator.SelectedIndex == 2)
                Config.Set("CSVSeparator", "TAB");
            else
                Config.Set("CSVSeparator", ",");

            Close(null, null);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Config.Get("SaveLastDirectory") == "1")
                saveLastDir.Checked = true;
            else
                saveLastDir.Checked = false;
            if (Config.Get("SaveUpdatesIn") == "Root" || Config.Get("SaveUpdatesIn") == "")
                saveUpdatesIn.SelectedIndex = 0;
            if (Config.Get("SaveUpdatesIn") == "Respective")
                saveUpdatesIn.SelectedIndex = 1;
            if (Config.Get("OpenFolderAfterDownloadingUpdates") == "1")
                openFolderAfterDownloadingUpdates.Checked = true;
            else
                openFolderAfterDownloadingUpdates.Checked = false;

            if (Config.Get("FilenameFormat") == "NameAndVersion")
                filenameFormat.SelectedIndex = 1;
            else if (Config.Get("FilenameFormat") == "IDAndNameAndVersion")
                filenameFormat.SelectedIndex = 2;
            else
                filenameFormat.SelectedIndex = 0;

            if (Config.Get("CheckFat32") == "1")
                checkFat32.Checked = true;
            else
                checkFat32.Checked = false;

            if (Config.Get("CSVSeparator") == ";")
                csvSeparator.SelectedIndex = 1;
            else if (Config.Get("CSVSeparator") == "TAB")
                csvSeparator.SelectedIndex = 2;
            else
                csvSeparator.SelectedIndex = 0;
        }

        private void Close(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}