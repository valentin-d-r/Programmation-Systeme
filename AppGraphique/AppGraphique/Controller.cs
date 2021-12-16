using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using AppGraphique.Model;
using System.Windows;
using System.Diagnostics;

namespace AppGraphique
{
    public class Controller
    {
        private SaveModel model;
        private Log logModel;
        private LogState logStateModel;
        private static Mutex mutex = new Mutex();


        public Controller()
        {
            model = new SaveModel();
            logModel = new Log();
            logStateModel = new LogState();
        }

        public void updateSaveInfo(SaveModel save)
        {
            mutex.WaitOne(); // Allows you to control access to the Log and LogStates resource. Allows each thread to be entered 1 by 1.
            model.Name = save.Name;
            model.Source = save.Source;
            model.Dest = save.Dest;
            model.createSave(save);

            logModel.Name = model.Name;
            logModel.Source = model.Source;
            logModel.Dest = model.Dest;
            logModel.FileTransferTime = model.FileTransferTime;
            logModel.Date = model.time_now();
            logModel.Size = model.Size;
            logModel.FileTransferTimeToCrypt = model.FileTransferTimetoCrypt;
            logModel.createLog(logModel);


            logStateModel.Name = model.Name;
            logStateModel.Source = model.Source;
            logStateModel.Dest = model.Dest;
            logStateModel.Date = model.time_now();
            logStateModel.State = model.State;
            logStateModel.createLogState(logStateModel);
            mutex.ReleaseMutex(); // Resource release 

        }
    }
}
