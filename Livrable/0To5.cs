using System;
namespace Livrable
{
    public class _To5
    {
        public int start = 1;
        public int final=1000;
        public int nombre;
        public string name;
        public string language;
        public void Programme()
        {
            // Choice of language
            Console.WriteLine("Language ? FR or EN");
            language = Console.ReadLine(); // We Grab the answer 


            // --- LANGUE FR --- // 
            if (language == "FR") // If the answer was FR
            {
                nombre = start;
                Console.WriteLine("Combien de fichier, voulez vous sauvegardé?"); // We Write into the console to have, the answer about how much save the user want to do
                final = Convert.ToInt32(Console.ReadLine()); // We Grab the answer
                while (nombre < final+1) // As long as the number of saves is smaller than the number entered, the same number of saves is required.
                {
                    Console.Clear();
                    // Copy of the directory, including, these child directories
                TemplateSave modele = new TemplateSave();
                Console.WriteLine("Comment voulez vous appelé votre sauvegarde?"); // We write into the console, how the user want to call the save?
                name = Console.ReadLine(); // We grab the answer
                Console.WriteLine("Fichier source ? : "); // We ask to the user, the source file
                string fichierSource = Console.ReadLine();// We Grab the answer
                //@"/Users/aymerick/Desktop/CESI/Informatique"; // Used only to the dev of the application.
                Console.WriteLine("Fichier destination ? : ");// We ask to the user, the dest file
                string fichierDest = Console.ReadLine();// We Grab the answer
                //@"/Users/aymerick/Desktop/CESI/TEST2";// Used only to the dev of the application.
                WriteLogsStates log2 = new WriteLogsStates(fichierSource, fichierDest, name); // We write in the State logs
                WriteLog log = new WriteLog(fichierSource, fichierDest,name); //We write in the logs
                log.Write(); // Launch of the write function, of the WriteLog class, to write the logs
                log2.write();
                nombre++; //We increase the number of saves to +1
                    if (log.calculTemps.ok)
                    {
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Console : SUCCESS");
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadLine();
                    }

                    else if (!log.calculTemps.ok)
                    {
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Console : ERROR");
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadLine();
                    }
                }

            // --- LANGUE EN --- // 
            }else if(language=="EN") //All comment are the same for EN and FR
            {
                nombre = start;
                Console.WriteLine("How much file, do u want to save?");
                final = Convert.ToInt32(Console.ReadLine());
             
                while (nombre < final+1)// As long as the number of saves is smaller than the number entered, the same number of saves is needed.
                {
                    Console.Clear();
                    // Copy from the current directory, include subdirectories.
                    TemplateSave modele = new TemplateSave();
                    Console.WriteLine("What do you want to call your backup?"); // Save's name?
                    name = Console.ReadLine(); // We grab the name, thanks to the console.
                    Console.WriteLine("Source File ? : ");
                    string fichierSource = Console.ReadLine();
                    //string fichierSource = @"/Users/aymerick/Desktop/CESI/Informatique";
                    Console.WriteLine("Destination file ? : ");
                    string fichierDest = Console.ReadLine();
                    //string fichierDest = @"/Users/aymerick/Desktop/CESI/TEST2";

                    WriteLog log = new WriteLog(fichierSource, fichierDest,name); //We write in the logs
                    WriteLogsStates log2 = new WriteLogsStates(fichierSource, fichierDest, name); // We write in the State logs
                    log2.write();
                    log.Write(); // Launch the write function, of the WriteLog class, to write the logs
                    nombre++; //We increase the number of saves to + 1
                    if (log.calculTemps.ok)
                    {
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Console : SUCCESS");
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadLine();
                    }else if(!log.calculTemps.ok)
                    {
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Console : ERROR");
                        Console.WriteLine("\r\n");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadLine();
                    }
                }

            }
    }
}
}
