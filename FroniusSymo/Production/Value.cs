using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FroniusSymo.Production
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Value
    {
        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("Values")]
        public Dictionary<string,string> Values { get; set; }

        public string Value1
        {
            get
            {
                string output = string.Empty;

                Values.TryGetValue("1", out output);

                return output;
            }
        }

        public Value()
        {
            Values = new Dictionary<string, string>();
        }
    }
}
