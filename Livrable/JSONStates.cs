using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Livrable
{
    public class JSONStates
    {
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public string sourceFile { get; set; }
        public string destinationFile { get; set; }
        public int states { get; set; }


    }
}
