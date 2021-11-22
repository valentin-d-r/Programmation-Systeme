using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Livrable
{
    public class WriteLog
    {
        public Save sauvegarde = new Save("Test", EnumStates.ACTIF, 10, 15);
        public string source;
        public string dest;
        public double taille;
        public CalculLenght calculTaille = new CalculLenght();
        public CalculTime calculTemps;
        public double temps;

        public WriteLog(string fichierSource, string fichierDest)
        {
            this.source = fichierSource;
            this.dest = fichierDest;
            this.taille = calculTaille.calculateFolderSize(source);
            calculTemps = new CalculTime(this.source, this.dest, EnumSave.COMPLET);
            this.temps = calculTemps.temps;
        }

        public void Write()
        {
            try
            {

                JsonTry log = new JsonTry();
                log.Date = Save.horodatage;
                log.name = sauvegarde.appellation;
                log.dest = dest;
                log.source = source;
                log.Lenght = taille;
                log.TimeForTheSave = temps;
                string json = JsonConvert.SerializeObject(log);

                string fileName = @"/Users/aymerick/Desktop/CESI/test.json";
                using (StreamWriter writer = new StreamWriter(@fileName, true))
                {
                    
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(log, options);
                    Console.Write(jsonString);
                    File.WriteAllText(@fileName, jsonString);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }
    }
}
