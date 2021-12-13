﻿/*using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;

namespace Projet.Model
{

    class DifferentialBackup : IBackup
    {
        // a method that will be used for the differential backup
        public void Sauvegarde(string sourcePATH, string destPATH, bool copyDirs, int getStateIndex, long fileCount, int getIndex, string getName)
        {
            //Initialize a timer which determine the backup time
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourcePATH);


            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourcePATH);
            }
            //condition in order to create the source subdirectories in the destination directory
            if (copyDirs)
            {
                CreateDirs(destPATH, dir.GetDirectories());
            }


            FileInfo[] files = copyDirs ? dir.GetFiles("*", SearchOption.AllDirectories) : dir.GetFiles();
            var i = 0;
            foreach (var file in files)
            {
                if (File.Exists(file.FullName.Replace(sourcePATH, destPATH)))
                {
                    using (var sourcef = File.OpenRead(file.FullName))
                    {
                        // opening the destination PATH
                        using (var destinationf = File.OpenRead(file.FullName.Replace(sourcePATH, destPATH)))
                        {
                            var hash1 = BitConverter.ToString(MD5.Create().ComputeHash(sourcef));
                            var hash2 = BitConverter.ToString(MD5.Create().ComputeHash(destinationf));
                            if (hash1 == hash2)
                            {
                                continue;
                            };
                        }
                    }
                    var jsonDataNo = File.ReadAllText(Etat.filePath); //Read the JSON file
                    var stateListNo = JsonConvert.DeserializeObject<List<Etat>>(jsonDataNo) ?? new List<Etat>(); //convert a string into an object for JSON
                }

                var json = File.ReadAllText(Settings.filePath);
                var List = JsonConvert.DeserializeObject<List<Settings>>(json) ?? new List<Settings>();
                string[] extensions = new string[] { List[0].extensionsAccepted };
                extensions = extensions[0].Split(',', ' ');
                TimeSpan TimeToCrypt = TimeSpan.Zero;

                if (extensions.Contains(file.Extension))
                {
                    var p = new Process();
                    p.StartInfo.FileName = @"..\..\..\CryptoSoft\CryptoSoft.exe";
                    p.StartInfo.Arguments = $"{file.FullName} {file.FullName.Replace(sourcePATH, destPATH)}";
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    p.Start();
                    timer.Stop();
                    TimeToCrypt += stopWatch.Elapsed;

                    var jsonState = File.ReadAllText(Etat.filePath); //Read the JSON file
                    var stateListCrypt = JsonConvert.DeserializeObject<List<Etat>>(jsonState) ?? new List<Etat>(); //convert a string into an object for JSON

                    stateListCrypt[getStateIndex].TimeToCrypt = TimeToCrypt.ToString();

                    string ResultJsonState = JsonConvert.SerializeObject(stateListCrypt, Formatting.Indented);  //convert an object into a string for JSON
                    File.WriteAllText(Etat.filePath, ResultJsonState);
                }
                else
                {
                    file.CopyTo(file.FullName.Replace(sourcePATH, destPATH), true); //Copies an existing file to a new file.
                }
                i++;
                var filesLeftToDo = Directory.GetFiles(sourcePATH, "*", SearchOption.AllDirectories).Length - i;
                string progress = Convert.ToString((100 - (filesLeftToDo * 100) / fileCount)) + "%";
                var jsonData = File.ReadAllText(Etat.filePath); //Read the JSON file
                var stateList = JsonConvert.DeserializeObject<List<Etat>>(jsonData) ?? new List<Etat>(); //convert a string into an object for JSON

                stateList[getStateIndex].NbFilesLeftToDo = filesLeftToDo.ToString();
                stateList[getStateIndex].Progression = progress;

                string strResultJsonState = JsonConvert.SerializeObject(stateList, Formatting.Indented);  //convert an object into a string for JSON
                File.WriteAllText(Etat.filePath, strResultJsonState);
                // Switch the language of the outpoot according to the choice of the user when he started the program
            }
            var jsonDataState2 = File.ReadAllText(Etat.filePath); //Read the JSON file
            var stateList2 = JsonConvert.DeserializeObject<List<Etat>>(jsonDataState2) ?? new List<Etat>(); //convert a string into an object for JSON

            stateList2[getStateIndex].Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            stateList2[getStateIndex].Progression = "100%";
            stateList2[getStateIndex].State = "END";

            string strResultJsonState2 = JsonConvert.SerializeObject(stateList2, Formatting.Indented);  //convert an object into a string for JSON
            File.WriteAllText(Etat.filePath, strResultJsonState2);

            var jsonDataState3 = File.ReadAllText(Work.filePath); //Read the JSON file
            var stateList3 = JsonConvert.DeserializeObject<List<Work>>(jsonDataState3) ?? new List<Work>(); //convert a string into an object for JSON

            stateList3.Remove(stateList3[getIndex]);

            string strResultJsonState3 = JsonConvert.SerializeObject(stateList3, Formatting.Indented);  //convert an object into a string for JSON
            File.WriteAllText(Work.filePath, strResultJsonState3);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            var jsonDataState4 = File.ReadAllText(Log.filePath); //Read the JSON file
            var stateList4 = JsonConvert.DeserializeObject<List<Log>>(jsonDataState4) ?? new List<Log>(); //convert a string into an object for JSON

            stateList4.Add(new Log()
            {
                Name = stateList2[getStateIndex].Name,
                FileSource = stateList2[getStateIndex].SourceFilePath,
                FileTarget = stateList2[getStateIndex].TargetFilePath,
                FileSize = stateList2[getStateIndex].TotalFilesSize,
                FileTransferTime = elapsedTime,
                time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });

            string strResultJsonState4 = JsonConvert.SerializeObject(stateList4, Formatting.Indented);  //convert an object into a string for JSON
            File.WriteAllText(Log.filePath, strResultJsonState4);
        }
        private void CreateDirs(string path, DirectoryInfo[] dirs)
        {
            foreach (var dir in dirs)
            {

                if (!Directory.Exists(Path.Combine(path, dir.Name)))
                {
                    Directory.CreateDirectory(Path.Combine(path, dir.Name));
                }
                CreateDirs(Path.Combine(path, dir.Name), dir.GetDirectories());
            }
        }
    }
}
*/