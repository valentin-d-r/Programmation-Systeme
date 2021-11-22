using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Livrable
{
    public class JSONStates
    {
        public DateTimeOffset Date { get; set; }
        public string name { get; set; }
        public string avancement { get; set; }


    }
}
