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

namespace Livrable
{
    class Model
    {
        private string name;
        private string source;
        private string dest;
        private double size;
        private DateTime timestamp;
        private string fileTransferTime;
        private string state;
        List<JsonTry> listJSON = new List<JsonTry>();
        List<JSONStates> listJSON2 = new List<JSONStates>();

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
        public double Size
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

        public Model()
        {
            Name = "";
            Source = "";
            Dest = "";
            Size = 0;
            Timestamp = default;
            FileTransferTime = default;

        }


        public void createSave()
        {
            State = "ACTIF";
            try
            {
                string path = Dest + @"\" + Name + ".";
                DateTime start = DateTime.Now;

                Timestamp = start;

                File.Copy(Source, path, true);
                DateTime stop = DateTime.Now;

                FileTransferTime = (stop - start).ToString();

                FileInfo file = new FileInfo(Source);
                Size = file.Length;

                Console.WriteLine("Success");
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }

            createLog();
            createLogState();
            State = "NON ACTIF";
            createLogState();
        }

        public void createLog()
        {
            JsonTry log = new JsonTry();
            log.Date = Timestamp;
            log.Name = Name;
            log.Dest = Dest;
            log.Source = Source;
            log.Size = Size;
            log.FileTransferTime = FileTransferTime;

            string json = JsonConvert.SerializeObject(log);

            string fileName = @"\Users\33624\Documents\GitHub\Test\test.json";


            if (!File.Exists(fileName))
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
            }
        }
        public void createLogState()
        {
            JSONStates log = new JSONStates();
            log.Date = Timestamp;
            log.Name = Name;
            log.Dest = Dest;
            log.Source = Source;
            log.State = State;
            if (log.State == "ACTIF")
            {
                //Truc en plus à mettre quand c'est actif ? Pas accès à l'ENT je peux pas voir
            }
            string json = JsonConvert.SerializeObject(log);

            string fileName = @"\Users\33624\Documents\GitHub\Test\test2.json";

            if (!File.Exists(fileName))
            {
                listJSON2.Add(log);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(listJSON2, options);
                File.WriteAllText(@fileName, jsonString);
            }
            else
            {
                StreamReader r = new StreamReader(fileName);
                string jsonString2 = r.ReadToEnd();
                r.Close();
                List<JSONStates> m = JsonConvert.DeserializeObject<List<JSONStates>>(jsonString2);
                m.Add(log);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString3 = System.Text.Json.JsonSerializer.Serialize(m, options);
                File.WriteAllText(@fileName, jsonString3);
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
}
