using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Livrable
{
    public class WriteLogsStates
    
        {
            public Save save;//CREER LA SAUVEGARDE EN ATTENDANT QUE LUILISATEUR LE FASSE
            public string source;
            public string dest;
            public double tailledest;
            public double taillesource;
            public CalculLenght calculTaille = new CalculLenght();
            public double temps;
            List<JSONStates> listJSON2 = new List<JSONStates>();


        public WriteLogsStates(string fichierSource, string fichierDest, string name)//construct a log with a source, a destination, a length and a time
            {
                this.save = new Save(name, fichierSource, fichierDest); ;
                this.source = save.source;
                this.dest = save.dest;
                this.taillesource = save.tailleFichiers;
                this.tailledest = calculTaille.calculateFolderSize(dest);

         
            }

        public void write()
        {

                JSONStates log = new JSONStates();
                log.Date = Save.horodatage;
                log.Name = save.appellation;
                log.destinationFile = dest;
                log.sourceFile = source;
                log.states = (int)save.etat;
               string json = JsonConvert.SerializeObject(log);

                string fileName = @"/Users/aymerick/Desktop/CESI/test2.json";


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
}
