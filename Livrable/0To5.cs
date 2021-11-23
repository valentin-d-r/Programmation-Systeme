using System;
namespace Livrable
{
    public class _To5
    {
        public int start = 1;
        public int final=1;
        public int nombre;
        public string language;
        public void Programme()
        {
            // Choix de la langue
            Console.WriteLine("Language ? FR or EN");
            language = Console.ReadLine();


            // --- LANGUE FR --- // 
            if (language == "FR")
            {
                nombre = start;
                Console.WriteLine("Combien de fichier, voulez vous sauvegardé?");
                Console.WriteLine("(max 5fichiers)");
                final = Convert.ToInt32(Console.ReadLine());
                if (final > 5) // SI travaux >5 arret du programme
                {
                    string fin = "Fin du programme, travaux de sauvegarde trop élévé";
                    Console.WriteLine(fin);
                    final = 0;
                } 
                while (nombre < final+1) // Tant que le le nombre de save est plus petit que le nombre entrée il faut autant de save.
            {
                // Copie du repertoire, y compris, ces repertoires enfants
                TemplateSave modele = new TemplateSave();
                
                Console.WriteLine("Fichier source ? : ");
                //Console.ReadLine();
                string fichierSource = @"/Users/aymerick/Desktop/CESI/Informatique";
                Console.WriteLine("Fichier destination ? : ");
                //Console.ReadLine();
                string fichierDest = @"/Users/aymerick/Desktop/CESI/TEST2";

                WriteLog log = new WriteLog(fichierSource, fichierDest); 
                log.Write(); // Lancement de la fonction write, de la classe WriteLog, pour écrire les logs
                nombre++; // On augmente le nombre de save à +1
                    Console.WriteLine("Console : SUCCESS");

                }

            // --- LANGUE EN --- // 
            }else if(language=="EN")
            {
                nombre = start;
                Console.WriteLine("How much file, do u want to save?");
                Console.WriteLine("(max 5files)");
                final = Convert.ToInt32(Console.ReadLine());
                if (final > 5)// IF Save >5 directly stop
                {
                    string fin = "End of work, too much thing to save";
                    Console.WriteLine(fin);
                    final = 0;
                }
                while (nombre < final+1)// As long as the number of saves is smaller than the number entered, the same number of saves is needed.
                {
                    // Copy from the current directory, include subdirectories.
                    TemplateSave modele = new TemplateSave();

                    Console.WriteLine("Source File ? : ");
                    //Console.ReadLine();
                    string fichierSource = @"/Users/aymerick/Desktop/CESI/Informatique";
                    Console.WriteLine("Destination file ? : ");
                    //Console.ReadLine();
                    string fichierDest = @"/Users/aymerick/Desktop/CESI/TEST2";

                    WriteLog log = new WriteLog(fichierSource, fichierDest);
                    log.Write(); // Launch the write function, of the WriteLog class, to write the logs
                    nombre++; //We increase the number of saves to + 1
                    Console.WriteLine("Console : SUCCESS");

                }
               
            }
    }
}
}
