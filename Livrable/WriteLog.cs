using System;
using System.IO;
namespace Livrable
{
    public class WriteLog
    {
        public Save sauvegarde = new Save("Test", EnumStates.ACTIF, 10, 15);
        public string source;
        public string dest;
        public int taille;
        public CalculLenght calculTaille = new CalculLenght();
        public CalculTime calculTemps;
        public double temps;

        public WriteLog(string fichierSource, string fichierDest)
        {
            this.source = fichierSource;
            this.dest = fichierDest;
            this.taille = this.source.Length;
            calculTemps = new CalculTime(this.source, this.dest, EnumSave.COMPLET);
            this.temps = calculTemps.temps;
        }

        public void Write()
        {
            try
            {
                string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Livrable1\Fichierlogs.txt";
                using (StreamWriter writer = new StreamWriter(@fileName, true))
                {
                    writer.WriteLine("{");
                    writer.WriteLine("time : " + Save.horodatage);

                    writer.WriteLine("name : " + this.sauvegarde.appellation);
                    writer.WriteLine("source : " + this.source);
                    writer.WriteLine("destination : " + this.dest);
                    writer.WriteLine("taille : " + this.calculTaille.calculateFolderSize(this.source) + " octets");
                    writer.WriteLine("temps sauvegarde : " + this.temps + " ms");
                    writer.WriteLine("}");
                    writer.WriteLine(" ");
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }
    }
}
