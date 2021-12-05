using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Livrable
{
    class View
    {
        public string name;
        public string source;
        public string dest;
        internal IController controller;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }

        public IController Controller
        {
            get { return controller; }
            set { controller = value; }
        }


        public View()
        {
            Name = "";
            Source = "";
            Dest = "";
        }

        public void saveInfo()
        {
            getName();
            getSource();
            getDest();
        }

        public void getName()
        {
            bool isNameValid = false;
            while (isNameValid != true)
            {
                Console.WriteLine("Veuillez entrez le nom de votre sauvegarde");
                Name = Console.ReadLine();
                if (Name != "")
                {
                    isNameValid = true;
                }
            }
        }

        public void getSource()
        {
            bool isSourceValid = false;
            while (isSourceValid != true)
            {
                Console.WriteLine("Veuillez le chemin source");
                Source = Console.ReadLine();
                isSourceValid = checkFilePath(Source);
            }
        }

        public void getDest()
        {
            bool isDestValid = false;
            while (isDestValid != true)
            {
                Console.WriteLine("Veuillez le chemin de destination");
                Dest = Console.ReadLine();
                isDestValid = checkDestPath(Dest);
            }
        }

        public bool checkFilePath(string filePath)
        {
            bool result = File.Exists(filePath);
            return result;
        }

        public bool checkDestPath(string destPath)
        {
            bool result = Directory.Exists(destPath);
            return result;
        }


        //link the view's to the controller
        public void setController(IController cont)
        {
            controller = cont;
        }

    }
}



