using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class ViewLog : View
    {
        private DateTime timestamp;
        private string size;
        private string fileTransferTime;

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public string FileTransferTime
        {
            get { return fileTransferTime; }
            set { fileTransferTime = value; }
        }
    }
}
