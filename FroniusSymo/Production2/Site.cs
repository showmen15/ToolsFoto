using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FroniusSymo.Production2
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Site
    {
        [JsonProperty("E_Day")]
        public double E_Day { get; set; }

        [JsonProperty("E_Year")]
        public double E_Year { get; set; }

        [JsonProperty("E_Total")]
        public double E_Total { get; set; }
    }
}
