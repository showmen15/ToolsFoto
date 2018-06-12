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

        public DateTime? timestamp
        {
            get
            {
                DateTime temp;

                if (DateTime.TryParse(head.Timestamp, out temp))
                    return temp;
                else
                    return null;
            }
        }

        public int Pac
        {
            get
            {
                return int.Parse(body.Pac.Value1);
            }
        }

        public int DayEnergy
        {
            get
            {
                return int.Parse(body.DayEnergy.Value1);
            }
        }

        public int YearEnergy
        {
            get
            {
                return int.Parse(body.YearEnergy.Value1);
            }
        }

        public int TotalEnergy
        {
            get
            {
                return int.Parse(body.TotalEnergy.Value1);
            }
        }

    }
}
