using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Livrable
{
    public class JsonTry
    {
        public DateTimeOffset Date { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public string dest { get; set; }
        public int taille { get; set; }
        public double tempsave { get; set; }



    }
}
