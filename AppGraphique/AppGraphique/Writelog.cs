using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace AppGraphique
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


        public WriteLog(string fichierSource, string fichierDest, string name)//construct a log with a source, a destination, a length and a time
        {
            this.save = new Save(name, fichierSource, fichierDest);
            this.source = fichierSource;
            this.dest = fichierDest;
            this.taille = this.save.tailleFichiers;
            calculTemps = new CalculTime(this.save);
            this.temps = calculTemps.temps;
        }

        public void Write() // Method Write
        {
            try
            {

                JsonTry log = new JsonTry();// We attribute all of our values thank to the classe JsonTry
                log.Date = Save.horodatage;
                log.Name = save.appellation;
                log.destinationFile = dest;
                log.sourceFile = source;
                log.Lenght = taille;
                log.TimeForTheSave = temps;
                string json = JsonConvert.SerializeObject(log);

                string fileName = @"C:\Users\Draugar\Desktop\test\test.json"; // Location of the log file


                if (!File.Exists(fileName)) // If the file log doesn't existe
                {
                    listJSON.Add(log);// We add to the list all information about log (JsonTry L.38)
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(listJSON, options);//Used to serialize the list 'ListJSON' in JSON format into jsonString
                    File.WriteAllText(@fileName, jsonString); // Write to file "fileName" all thing into jsonString
                }
                else // If the file log existe
                {
                    StreamReader r = new StreamReader(fileName);
                    string jsonString2 = r.ReadToEnd();//We put in the JsonString2 variable, all the content of the FileName file in json
                    r.Close();// We close the file
                    List<JsonTry> m = JsonConvert.DeserializeObject<List<JsonTry>>(jsonString2);// We put the content of the file in the new list, deserialize.That is to say, we change the format.
                    m.Add(log); // We add to the list all information about log (JsonTry L.38)
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString3 = System.Text.Json.JsonSerializer.Serialize(m, options); //Used to serialize the list 'm' in JSON format into jsonString3
                    File.WriteAllText(@fileName, jsonString3);// Write to file "fileName" all thing into jsonString3
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }
    }
}