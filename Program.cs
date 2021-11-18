using System;
using System.IO;

namespace Livrable1
{
    class Program
    {
        static void Main(string[] args)
        {
            string FRorEN="CC";
            if (FRorEN=="CC")
            {
            Console.WriteLine("-----------");
            Console.WriteLine("Language ? ");
            Console.WriteLine("FR");
            Console.WriteLine("EN");
            Console.WriteLine("-----------");
            FRorEN = Console.ReadLine();
            Console.WriteLine(FRorEN);
            }
            switch (FRorEN)
            {
                case "EN":

                    break;
                case "FR":
                    Console.WriteLine("-----------");
                    Console.WriteLine("Que voulez vous faire?");
                    Console.WriteLine("Sauvegarde");
                    Console.WriteLine("Exécution séquentielle");
                    Console.WriteLine("-----------");
                    string Choix = Console.ReadLine();
                    
                    switch (Choix)
                    {
                        case "Sauvegarde":
                            // COPY
                            Console.WriteLine("Entre le nom de ta sauvegarde ? ");
                            string namesave = Console.ReadLine();
                            Console.WriteLine("Dossier source ? : ");
                            string fichiersource = Console.ReadLine();
                            Console.WriteLine("Dossier destination ? : ");
                            string fichierdest = Console.ReadLine();
                            DirectoryCopy(@fichiersource, @fichierdest, true);

                            // Création du fichier LOG
                            int taille = fichiersource.Length;
                            StreamWriter sw = new StreamWriter("C:\\Test.txt");
                            sw.WriteLine("Nom : ", namesave);
                            sw.WriteLine(fichiersource);
                            sw.WriteLine(fichierdest);
                            sw.WriteLine(taille);
                            sw.WriteLine(DateTime.Now);
                            sw.WriteLine(DateTime.Now.Hour);
                            sw.WriteLine(DateTime.Now.Minute);
                            break;
                        case "Exécution":

                            break;
                    }//fin du switch

                   
                        
                    

                    break;
            }//fin du switch
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
