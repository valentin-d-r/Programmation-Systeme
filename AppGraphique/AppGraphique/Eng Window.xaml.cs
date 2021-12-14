using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Resources;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using Microsoft.Win32;
using AppGraphique.Model;

namespace AppGraphique
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public List<SaveModel> saveList = new List<SaveModel>();
        public List<Thread> threadList = new List<Thread>();

        #region GETER AND SETER
        /*public string Name
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
        }*/
        #endregion
        public Window2(Controller controller)
        {
            /*this.Controller = controller;*/
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                TextboxSourceEng.Text = openDlg.SelectedPath;

                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {
                MessageBox.Show("You didn't choose a directory !!!");
            }

        }

        private void DestinationPath_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                TextboxDestinationEng.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show("You didn't choose a directory !!!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Menu = new MainWindow();
            Menu.Show();
            this.Close();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Process[] process = Process.GetProcessesByName("Calculator");
            if (process.Length > 1)
            {
                MessageBox.Show("Veuillez arreter le processus en cours");
                Environment.Exit(0);
            }
            else
            {
                //Controller.updateSaveInfo(Name, Source, Dest);

                /*for (int i = 0; i < saveList.Count; i++)
                {

                    SaveModel save = saveList[i];

                    Thread thread = new Thread(() => Controller.updateSaveInfo(save.getName(), save.getSource(), save.getDest()));
                    threadList.Add(thread);
                }


                for (int j = 0; j < threadList.Count; j++)
                {
                    threadList[j].Start();
                }*/
            }

            /*Name = tbSelectSomeText.Text;
            Source = TextboxSourceEng.Text;
            Dest = TextboxDestinationEng.Text;
            Controller.updateSaveInfo(Name, Source, Dest);*/
        }

        private void TextboxSourceEng_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name  = tbSelectSomeText.Text;

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"..\..\..\extensions.json");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"..\..\..\Priorite.json");
        }

        /*private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            /*
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Multiselect = true;
            dialog.InitialDirectory = TextboxSourceEng.Text;
            if (TextboxSourceEng.Text != "") { dialog.ShowDialog(); } else { MessageBox.Show("veuillez entrer un chemin valide"); }

            foreach (var file in dialog.FileNames)
            {
                /*var fileToCrypt = file.Replace(TextboxSourceEng.Text, TextboxDestinationEng.Text);
                Prosoft dr = new Prosoft();
                dr.Cryptage(file, fileToCrypt);
            }
        */
    }      
}
