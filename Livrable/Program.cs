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
            //Console.ReadLine();
            string fichierSource = @"/Users/aymerick/Desktop/CESI/Informatique";
            Console.WriteLine("Fichier destination ? : ");
            //Console.ReadLine();
            string fichierDest = @"/Users/aymerick/Desktop/CESI/TEST2";

            WriteLog log = new WriteLog(fichierSource, fichierDest);
            log.Write();

        }
    }
}
