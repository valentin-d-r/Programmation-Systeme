using System;
using System.Diagnostics;
using System.Threading;
namespace Livrable
{
    public class CalculTime
    {
        public double temps;
        public TemplateSave modeleSauv;

        public CalculTime(string source, string dest, EnumSave typeSauv)
        {
            if (typeSauv == EnumSave.COMPLET)
            {
                Stopwatch sw = Stopwatch.StartNew();
                this.modeleSauv = new TemplateSave();
                this.modeleSauv.SaveAll(source, dest, true);
                sw.Stop();
                this.temps = sw.Elapsed.TotalMilliseconds;
            }
            if (typeSauv == EnumSave.DIFFERENTIEL)
            {
                Stopwatch sw = Stopwatch.StartNew();
                this.modeleSauv = new TemplateSave();
                this.modeleSauv.SaveDiff(source, dest, true);
                sw.Stop();
                this.temps = sw.Elapsed.TotalMilliseconds;
            }
        }
    }
}
