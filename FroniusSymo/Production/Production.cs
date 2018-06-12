using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FroniusSymo.Common;

namespace FroniusSymo.Production
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Production
    {
        [JsonProperty("Head")]
        public Head head { get; set; }

        [JsonProperty("Body")]
        public Body body { get; set; }

        public Production()
        {
            head = new Head();
            body = new Body();
        }
    }
}
