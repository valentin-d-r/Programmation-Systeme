using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Livrable
{
    public class WriteLog
    {
        public Save save;
        public string source;
        public string dest;
        public double taille;
        public CalculLenght calculTaille = new CalculLenght();
        public CalculTime calculTemps;
        public double temps;
        List<JsonTry> listJSON = new List<JsonTry>();


        public WriteLog(string fichierSource, string fichierDest)//construct a log with a source, a destination, a length and a time
        {
            this.save = new Save("Test", fichierSource, fichierDest);
            this.source = fichierSource;
            this.dest = fichierDest;
            this.taille = this.save.tailleFichiers;
            calculTemps = new CalculTime(this.save);
            this.temps = calculTemps.temps;
        }

        public void Write()
        {
            try
            {

                JsonTry log = new JsonTry();
                log.Date = Save.horodatage;
                log.name = save.appellation;
                log.dest = dest;
                log.source = source;
                log.Lenght = taille;
                log.TimeForTheSave = temps;
                string json = JsonConvert.SerializeObject(log);

                string fileName = @"/Users/aymerick/Desktop/CESI/test.json";


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
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }
    }
}

