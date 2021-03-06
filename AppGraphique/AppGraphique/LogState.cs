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
    public class LogState
    {
        string name;
        string source;
        string dest;
        private string date;
        private string state;

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
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion

        public void createLogState(LogState logState)
        {

            List<JSONStates> listJSON2 = new List<JSONStates>();
            //string json = JsonConvert.SerializeObject(logState);
            Directory.CreateDirectory(@"C:\Backup\LogState");

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(logState, options);
            File.AppendAllText(@"\Backup\LogState\LogState.json", jsonString);

            /*string fileName = @"\Backup\LogState\LogState.json";

            if (!File.Exists(fileName))
            {
                listJSON2.Add(logState);
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
                m.Add(logState);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString3 = System.Text.Json.JsonSerializer.Serialize(m, options);
                File.WriteAllText(@fileName, jsonString3);
            }*/
        }
    }
}
