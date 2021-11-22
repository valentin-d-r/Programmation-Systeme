using System;

namespace Livrable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Copy from the current directory, include subdirectories.
            TemplateSave modele = new TemplateSave();

            Console.WriteLine("Fichier source ? : ");
            string fichierSource = @"/Users/aymerick/Desktop/CESI/Informatique";
            Console.WriteLine("Fichier destination ? : ");
            string fichierDest = @"/Users/aymerick/Desktop/CESI/TEST2";

            WriteLog log = new WriteLog(fichierSource, fichierDest);
           
            log.Write();
            




            // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\"
            // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test"
        }
    }
}
