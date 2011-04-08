using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PS3GameDetector
{
    class FTPData
    {
        private int _messageType;
        private string _message;

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public int Type
        {
            get
            {
                return _messageType;
            }
        }

        public FTPData(int type, string message)
        {
            _messageType = type;
            _message = message;
        }
    }
}
