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
using System.Windows.Shapes;

namespace AppGraphique
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        string Dest;
        string Source;
        new string Name;
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
                Source = openDlg.SelectedPath;

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
                Dest = openDlg.SelectedPath;
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
            if (tbSelectSomeText.Text != "" && TextboxSourceEng.Text != "" && TextboxDestinationEng.Text != "")
            {
                WriteLogsStates log2 = new WriteLogsStates(Source, Dest, Name);
                WriteLog log = new WriteLog(Source, Dest, Name); //We write in the logs
                log.Write(); // Launch of the write function, of the WriteLog class, to write the logs
                log2.write();
            }
        }

        private void TextboxSourceEng_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name  = tbSelectSomeText.Text;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"..\..\..\extensions.json");
        }
    }
}
