using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FroniusSolarResponses
    {
        [JsonProperty("Head")]
        public Head head {get;set;}

        [JsonProperty("Body")]
        public Body body { get; set; }
    }
}
