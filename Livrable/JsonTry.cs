using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Livrable
{
    public class JsonTry
    {
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public string sourceFile { get; set; }
        public string destinationFile { get; set; }
        public double Lenght { get; set; }
        public double TimeForTheSave { get; set; }



    }
}
