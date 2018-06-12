using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FroniusSymo.Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Head
    {
        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }
    }
}
