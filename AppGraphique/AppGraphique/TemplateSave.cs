using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace AppGraphique
{
    public class TemplateSave
    {
        public int comp;
        public bool Copy = true;
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
                if (file.Extension == ".exe")
                {
                    MessageBox.Show("Présence d'un logiciel ! Sauvegarde INTERDITE");
                    break;
                }
            }
            var json = File.ReadAllText(@"..\..\..\Extensions.json");
            var List = JsonConvert.DeserializeObject<List<Extension>>(json) ?? new List<Extension>();

            string[] extensions = new string[] { List[0].extensionsAccepted};
            extensions = extensions[0].Split(',', ' ');
            foreach (FileInfo file in files)
            {
                if (extensions.Contains(file.Extension))
                {
                    var fileToCrypt = file.FullName.Replace(sourceDirName, destDirName);
                    var p = new Process();
                    p.StartInfo.FileName = @"..\..\..\CryptoSoft\CryptoSoft.exe";
                    p.StartInfo.Arguments = $"{file} {fileToCrypt}";
                    p.Start();
                }
                else
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, false);
                }

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
            return Copy;
        }
    }
}