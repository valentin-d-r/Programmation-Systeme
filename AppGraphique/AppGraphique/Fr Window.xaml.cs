﻿using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
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
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {
                MessageBox.Show("Le répertoire de destination précisé est vide");
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
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show("Le répertoire source précisé est vide");
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Multiselect = true;
            dialog.InitialDirectory = TextboxSourceFR.Text;
            if (TextboxSourceFR.Text != "") { dialog.ShowDialog(); } else { MessageBox.Show("veuillez entrer un chemin valide"); }
        }
    }
}