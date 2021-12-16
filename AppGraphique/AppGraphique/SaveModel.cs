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
using System.Text;
using System.IO;
using System.Diagnostics;
namespace AppGraphique
{
    public class SaveModel
    {
        private string name;
        public string source;
        private string dest;
        private long size;
        private DateTime timestamp;
        private double fileTransferTime;
        private string state;
        private bool Copy = true;
        public string[] ext;
        double time_exec;
        public static int nbfile;


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
        public void setSize(long size2)
        {
            this.size = size2;


        }
        public string[] get_ext()
        {
            return this.ext;
        }
        public void set_ext(string[] ext)
        {
            this.ext = ext;
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
        public double Time_exec
        {
            get { return time_exec; }
            set { time_exec = value; }
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
        public double FileTransferTime
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
            State = "FINI";

        }
        public string time_now()
        {
            DateTime time = DateTime.Now;
            string time2 = time.ToString();
            return time2;
        }



        public void createSave(SaveModel save)
        {

            string dest = save.getDest();
            string[] ext = save.get_ext();
            string source = save.getSource();
            Stopwatch sw = Stopwatch.StartNew();
            state = "EnCour";

            DirectoryInfo disource = new DirectoryInfo(source);
            long taille = calculateFolderSize(disource);
            size = calculateFolderSize(disource);

            foreach (var directory in Directory.GetDirectories(source))
            {
                string dirName = Path.GetFileName(directory);
                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                    Console.Write(Path.Combine(dest, dirName));
                }
                source = directory;
                dest = Path.Combine(dest, dirName);
                createSave(save);
            }

            nbfile = 0;

            List<string> listFilePrio = new List<string>();
            List<string> listFileNoPrio = new List<string>();

            foreach (var file in Directory.GetFiles(source))
            {
                foreach (string extention in ext)
                {
                    if (Path.GetExtension(file).Equals(extention, StringComparison.InvariantCultureIgnoreCase))
                    {
                        listFilePrio.Add(file);
                    }
                    else
                    {
                        listFileNoPrio.Add(file);
                    }
                }
            }
            FileInfo[] files = disource.GetFiles();
            var json = File.ReadAllText(@"..\..\..\Extensions.json");
            var List = JsonConvert.DeserializeObject<List<Extension>>(json) ?? new List<Extension>();

            string[] extensions = new string[] { List[0].extensionsAccepted };
            extensions = extensions[0].Split(',', ' ');
            foreach (FileInfo file in files)
            {
                if (extensions.Contains(file.Extension))
                {
                    var fileToCrypt = file.FullName.Replace(source, dest);
                    var p = new Process();
                    p.StartInfo.FileName = @"..\..\..\CryptoSoft\CryptoSoft.exe";
                    p.StartInfo.Arguments = $"{file} {fileToCrypt}";
                    p.Start();
                }
            }
            foreach (var fileprio in listFilePrio)
            {

                File.Copy(fileprio, Path.Combine(dest, Path.GetFileName(fileprio)));
                nbfile++;
            }

            foreach (var filenoprio in listFileNoPrio)
            {
                File.Copy(filenoprio, Path.Combine(dest, Path.GetFileName(filenoprio)));
                nbfile++;
            }

 

            sw.Stop();
            fileTransferTime = sw.Elapsed.TotalMilliseconds;
            state = "Fini";
        }
        public long calculateFolderSize(DirectoryInfo d)
        {
            long Size = 0;
            // Ajoute taille des fichiers
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Ajoute taille des sous répertoires
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += calculateFolderSize(di);
            }
            return (Size);
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
        private string date;
        private string name;
        private string source;
        private string dest;
        private string state;

        #region GETER AND SETER
        public string Date
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
}
