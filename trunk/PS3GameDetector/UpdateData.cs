using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PS3GameDetector
{
    class UpdateData
    {
        private bool _updateSuccess;
        private string _updateContent;
        private XmlDocument xmlParser = new XmlDocument();
        private XmlNodeList _updateVersions;
        private string _updateVersion;
        private string _updateSize;
        private string _updateURL;
        private string _updateFileName;
        private string _updateGameName = "Unknown";

        public bool Status
        {
            get
            {
                return _updateSuccess;
            }
        }

        public string Version
        {
            get
            {
                return _updateVersion;
            }
        }

        public string Size
        {
            get
            {
                return _updateSize;
            }
        }

        public string URL
        {
            get
            {
                return _updateURL;
            }
        }

        public string FileName
        {
            get
            {
                return _updateFileName;
            }
        }

        public UpdateData(string updateContent)
        {
            _updateContent = updateContent;
            try
            {
                xmlParser.LoadXml(_updateContent);
                if (xmlParser.SelectSingleNode("//titlepatch").Attributes["status"].Value == "alive")
                {
                    _updateVersions = xmlParser.SelectNodes("//titlepatch/tag/package");
                    if (_updateVersions.Count > 0)
                    {
                        _updateSuccess = true;
                        for (int i = 0; i < _updateVersions.Count; i++)
                        {
                            _updateVersion = _updateVersions[i].Attributes["version"].Value;
                            _updateSize = _updateVersions[i].Attributes["size"].Value;
                            _updateURL = _updateVersions[i].Attributes["url"].Value;
                            _updateFileName = _updateURL.Substring(_updateURL.LastIndexOf("/") + 1);
                            try
                            {
                                _updateGameName = xmlParser.SelectSingleNode("//titlepatch/tag/package/paramsfo/TITLE").Value;
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                        _updateSuccess = false;
                   }
                else
                    _updateSuccess = false;
            }
            catch (XmlException e)
            {
                _updateSuccess = false;
                Console.WriteLine(e.Message);
            }
        }
    }
}
