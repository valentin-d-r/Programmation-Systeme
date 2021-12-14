using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using AppGraphique.Model;

namespace AppGraphique
{
    public class SaveModel
    {
        private string name;
        private string source;
        private string dest;
        private long size;
        private DateTime timestamp;
        private string fileTransferTime;
        private string state;
        private bool Copy = true;
        /*List<JsonTry> listJSON = new List<JsonTry>();
        List<JSONStates> listJSON2 = new List<JSONStates>();*/
        public string getSource()
        {
           return source;
      
        }
        public string getDest()
        {
            return dest;

        }
        public string getName()
        {
           return name;
   
        }
        public void setSource(string source2)
        {
           this.source=source2;

        }
        public void setDest(string dest2)
        {
            this.dest = dest2;

        }
        public void setName(string name2)
        {
            this.Name = name2;


        }
        #region GETER AND SETER
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }
        public long Size
        {
            get { return size; }
            set { size = value; }
        }
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public string FileTransferTime
        {
            get { return fileTransferTime; }
            set { fileTransferTime = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion

        public SaveModel()
        {
            Name = "";
            Source = "";
            Dest = "";
            Size = 0;
            Timestamp = default;
            FileTransferTime = default;
            State = "ACTIF";

        }


        public void createSave(Log logModel, LogState logStateModel)
        {

            State = "ACTIF";
            DirectoryInfo dir = new DirectoryInfo(Source);
            DirectoryInfo dest = new DirectoryInfo(Dest); 
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(Dest);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Extension);
                if (file.Extension == ".exe") // MERCI MAC QUI POUR .APP = .PLIST ????  AU FINAL CA FONCTIONNE PTDR
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Présence d'un logiciel ! Sauvegarde INTERDITE");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Copy = false;
                    Directory.Delete(Dest, true);

                    /*return Copy;*/
                }
                string tempPath = Path.Combine(Dest, file.Name);
                file.CopyTo(tempPath, false);


            }
            // If copying subdirectories, copy them and their contents to new location.
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(Dest, subdir.Name);
                    createSave(logModel, logStateModel);
                }
        }

        
        
    }
    public class JsonTry
    {
        private DateTime date;
        private string name;
        private string source;
        private string dest;
        private double size;
        private string fileTransferTime;

        #region GETER AND SETER
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Name
        {
            get { return name; }
            set { Name = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }
        public double Size
        {
            get { return size; }
            set { size = value; }
        }
        public string FileTransferTime
        {
            get { return fileTransferTime; }
            set { fileTransferTime = value; }
        }
        #endregion
    }

    public class JSONStates
    {
        private DateTime date;
        private string name;
        private string source;
        private string dest;
        private string state;

        #region GETER AND SETER
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Name
        {
            get { return name; }
            set { Name = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion
    }

    public class CalculLenght
    {
        public int numberfichier;

        public float calculateFolderSize(string folder)
        {
            float size = 0.0f;
            try
            {
                //Checks if the path is valid or not
                if (!Directory.Exists(folder))
                    return size;
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            if (File.Exists(file))
                            {
                                numberfichier++;
                                FileInfo finfo = new FileInfo(file);
                                size += finfo.Length;
                            }
                        }

                        foreach (string dir in Directory.GetDirectories(folder))
                            size += calculateFolderSize(dir);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return size;
        }
    }
}
