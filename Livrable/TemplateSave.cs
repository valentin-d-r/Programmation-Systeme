using System;
using System.IO;
namespace Livrable
{
    public class TemplateSave
    {
    public int comp;
        public bool canCopy = true;
    public bool SaveAll(string sourceDirName, string destDirName, bool copySubDirs)
    {

        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo dest = new DirectoryInfo(destDirName);

        if (dest.Exists)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(destDirName, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
        }

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
                if (file.Extension == ".plist") // MERCI MAC QUI POUR .APP = .PLIST ???? 
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Présence d'un logiciel ! Sauvegarde INTERDITE");
                    Console.ForegroundColor = ConsoleColor.Black;
                    canCopy = false;
                    Directory.Delete(destDirName,true);
                    return canCopy;
                }
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, false);
                    
        }
        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                SaveAll(subdir.FullName, tempPath, copySubDirs);
            }
        }
            return canCopy;
    }
}
}