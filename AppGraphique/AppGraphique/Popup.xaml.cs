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

        private void pbstatus1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*
            //Récupérer l'état d'avancement
            //création, initialisation et mise à jour de l'objet BackgroundWorker
			demandeInfoServer();
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;
			worker.RunWorkerAsync();
		
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
