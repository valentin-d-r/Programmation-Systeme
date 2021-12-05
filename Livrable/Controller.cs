using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Livrable
{
    class Controller : IController
    {
        private Model model;
        private View view;
        private ViewLog viewLog;
        private ViewLogState viewLogState;

        public Controller()
        {
            model = new Model();
            view = new View();
            viewLog = new ViewLog();
            viewLogState = new ViewLogState();

            view.setController(this);
            viewLogState.setController(this);

            view.saveInfo();

            public void updateSaveInfo()
            {

                view.saveInfo();
            }
        }
    }
}
