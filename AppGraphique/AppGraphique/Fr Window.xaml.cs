using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string name;
        private string source;
        private string dest;
        Controller Controller;
        private Controller controller;

        #region GETER AND SETER
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
        #endregion

        public Window1()
        {
            this.Controller = controller;
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
                TextboxSourceFR.Text = openDlg.SelectedPath;
                Source = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {
                MessageBox.Show("Vous n'avez pas choisi de répertoire !!!");
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
                TextboxDestinationFR.Text = openDlg.SelectedPath;
                Dest = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show("Vous n'avez pas choisi de répertoire !!!");
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Menu = new MainWindow();
            Menu.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = tbSelectSomeTextFR.Text;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Name = tbSelectSomeTextFR.Text;
            Source = TextboxSourceFR.Text;
            Dest = TextboxDestinationFR.Text;
            Controller.updateSaveInfo(Name, Source, Dest);
        }
    }
}