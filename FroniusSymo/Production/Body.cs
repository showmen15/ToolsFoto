using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FroniusSymo.Production
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Body
    {
        [JsonProperty("PAC")]
        public Value Pac { get; set; }

        [JsonProperty("DAY_ENERGY")]
        public Value DayEnergy { get; set; }

        [JsonProperty("YEAR_ENERGY")]
        public Value YearEnergy { get; set; }

        [JsonProperty("TOTAL_ENERGY")]
        public Value TotalEnergy { get; set; }

        public Body()
        {
            Pac = new Value();
            DayEnergy = new Value();
            YearEnergy = new Value();
            TotalEnergy = new Value();

        }
    }
}
