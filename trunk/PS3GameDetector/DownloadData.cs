using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PS3GameDetector
{
    class DownloadData
    {
        private long _bytesDownloaded;
        private long _bytesTotal;

        public long DownloadedBytes
        {
            get
            {
                return _bytesDownloaded;
            }
        }

        public long TotalBytes
        {
            get
            {
                return _bytesTotal;
            }
        }

        public DownloadData(long bytesDownloaded, long bytesTotal)
        {
            _bytesDownloaded = bytesDownloaded;
            _bytesTotal = bytesTotal;
        }
    }
}
