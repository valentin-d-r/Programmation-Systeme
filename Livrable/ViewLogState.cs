using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class ViewLogState : ViewLog
    {
        private string state;
        private int totalFileToCopy;
        private long totalFileSize;
        private int nbFileLeftToDo;
        private long fileSizeLeftToDo;

        #region GETER AND SETER
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public int TotalFileToCopy
        {
            get { return totalFileToCopy; }
            set { totalFileToCopy = value; }
        }
        public long TotalFileSize
        {
            get { return totalFileSize; }
            set { totalFileSize = value; }
        }
        public int NbFileLeftToDo
        {
            get { return nbFileLeftToDo; }
            set { nbFileLeftToDo = value; }
        }
        public long FileSizeLeftToDo
        {
            get { return fileSizeLeftToDo; }
            set { fileSizeLeftToDo = value; }
        }
        #endregion

        public ViewLogState()
        {
            State = "";
            TotalFileToCopy = 0;
            TotalFileSize = 0;
            NbFileLeftToDo = 0;
            FileSizeLeftToDo = 0;
        }

        public void stateLogInfo()
        {

        }
    }
}
