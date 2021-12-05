using System;
using System.Diagnostics;
using System.Threading;
namespace Livrable
{
    public class CalculTime
    {
        public double temps;
        public TemplateSave modeleSauv;
        public Save sauvegarde;
        public bool ok;

        public CalculTime(Save sauvegarde) //calculate the time and start the backup
        {
            this.sauvegarde = sauvegarde;
            this.sauvegarde.etat = EnumStates.ENCOURS;
            Stopwatch sw = Stopwatch.StartNew(); //start a counter
            
            this.modeleSauv = new TemplateSave(); //create a backup 
            ok = this.modeleSauv.SaveAll(this.sauvegarde.source, this.sauvegarde.dest, true);
            sw.Stop();
            this.sauvegarde.etat = EnumStates.END;
            this.temps = sw.Elapsed.TotalMilliseconds;//stop counter and return time use to do the backup

        }
    }
}
