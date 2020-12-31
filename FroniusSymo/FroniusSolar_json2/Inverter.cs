using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar_json2
{
    [JsonObject(Description ="test",Id = "Inverter")]
    public class Inverter
    {
        public string NodeType { get; set; }
        public DateTime End { get; set; }

    }
}
