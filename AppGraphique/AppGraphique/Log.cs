using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using Newtonsoft.Json;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppGraphique.Model
{
    public class Log
    {
        string name;
        string source;
        string dest;
        private string date;
        private long size;
        private double fileTransferTime;

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
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public long Size
        {
            get { return size; }
            set { size = value; }
        }
        public double FileTransferTime
        {
            get { return fileTransferTime; }
            set { fileTransferTime = value; }
        }
        #endregion

        public void createLog(Log log)
        {

            List<JsonTry> listJSON = new List<JsonTry>();
           // string json = JsonConvert.SerializeObject(log);
            Directory.CreateDirectory(@"C:\Backup\Logs");



            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(log, options);
            File.AppendAllText(@"\Backup\Logs\Logs.json", jsonString);


            /*if (!File.Exists(fileName))
            {
                listJSON.Add(log);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(listJSON, options);
                File.WriteAllText(@fileName, jsonString);
            }
            else
            {
                StreamReader r = new StreamReader(fileName);
                string jsonString2 = r.ReadToEnd();
                r.Close();
                List<JsonTry> m = JsonConvert.DeserializeObject<List<JsonTry>>(jsonString2);
                m.Add(log);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString3 = System.Text.Json.JsonSerializer.Serialize(m, options);
                File.WriteAllText(@fileName, jsonString3);
            }*/
        }

    }
}
