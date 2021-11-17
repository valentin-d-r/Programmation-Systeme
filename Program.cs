using System;

namespace Livrable1
{
    class Program
    {
        static void Main(string[] args)
        {
            string FRorEN="CC";
            if (FRorEN=="CC")
            {
            Console.WriteLine("Language ? ");
            Console.WriteLine("FR");
            Console.WriteLine("EN");
            FRorEN = Console.ReadLine();
            Console.WriteLine(FRorEN);
            }
            switch (FRorEN)
            {
                case "EN":

                    break;
                case "FR":
                    Console.WriteLine("Que voulez vous faire?");
                    Console.WriteLine("Sauvegarde");
                    Console.WriteLine("Exécution séquentielle");
                    string Choix = Console.ReadLine();
                    
                    switch (Choix)
                    {
                        case "Sauvegarde":
                            //Console.WriteLine("Fichier source");
                            //string sourceFile = Console.ReadLine();
                            string sourceFile = @"/Users";

                            //Console.WriteLine("Fichier destination");
                            //string destinationFile = Console.ReadLine();
                            string destinationFile = @"/Users/Cool";

                            // To move a file or folder to a new location:
                            System.IO.File.Move(sourceFile, destinationFile);

                            // To move an entire directory. To programmatically modify or combine
                            // path strings, use the System.IO.Path class.
                            System.IO.Directory.Move(sourceFile, destinationFile);
                            // Keep console window open in debug mode.
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                            break;
                        case "Exécution":
                            break;
                    }//fin du switch

                   
                        
                    

                    break;
            }//fin du switch
        }
    }
}
