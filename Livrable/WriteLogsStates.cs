using System;
namespace Livrable
{
    public class WriteLogsStates
    
        {
            public Save sauvegarde;//CREER LA SAUVEGARDE EN ATTENDANT QUE LUILISATEUR LE FASSE
            public string source;
            public string dest;
            public double tailledest;
            public double taillesource;
            public CalculLenght calculTaille = new CalculLenght();
            public CalculTime calculTemps;
            public double temps;


            public WriteLogsStates(Save sauvegarde)//construct a log with a source, a destination, a length and a time
            {
                this.sauvegarde = sauvegarde;
                this.source = sauvegarde.source;
                this.dest = sauvegarde.dest;
                this.taillesource = sauvegarde.tailleFichiers;
                this.tailledest = calculTaille.calculateFolderSize(dest);
                calculTemps = new CalculTime(this.sauvegarde);
                this.temps = calculTemps.temps;
            }
        /*public string WriteLogs()
        {
            JSONStates log = new JSONStates();
                log.Date = Save.horodatage;
                log.name = sauvegarde.appellation;
                log.avancement = 
                string json = JsonConvert.SerializeObject(log);
        }*/
    }
}
