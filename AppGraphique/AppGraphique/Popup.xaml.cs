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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AppGraphique
{
    /// <summary>
    /// Logique d'interaction pour PopupFR.xaml
    /// </summary>
    public partial class PopupFR : Window
    {
        public PopupFR()
        {
            InitializeComponent();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i = i + 99)
            {
                (sender as BackgroundWorker).ReportProgress(i);

                Thread.Sleep(2000);

            }
        }


        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //initialisation de la barre de progression avec le pourcentage de progression
            pbstatus1.Value = e.ProgressPercentage;

            //Affichage de la progression sur un label
            lb_etat_prog_server.Content = pbstatus1.Value.ToString() + "%";



        }

        private void pbstatus1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //création, initialisation et mise à jour de l'objet BackgroundWorker
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }
    }
}
