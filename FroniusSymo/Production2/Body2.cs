using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FroniusSymo.Production2
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Body2
    {
        [JsonProperty("Site")]
        public Site site { get; set; }

        public Body2()
        {
            site = new Site();
        }
    }
}
