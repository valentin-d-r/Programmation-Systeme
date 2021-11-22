using System;
namespace Livrable
{
    public class _To5
    {
        public int start = 0;
        public int final=5;
        public int nombre;
        public void Programme()
        {
            nombre = start;
            while (nombre < final)
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
                nombre++;

            }
            if (nombre > 4)
            {
                string fin = "Fin du programme, travaux de sauvegarde trop élévé";
                Console.WriteLine(fin);
            }
        }
    }
}
