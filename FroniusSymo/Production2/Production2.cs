using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FroniusSymo.Common;

namespace FroniusSymo.Production2
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Production2
    {
        #region :: Json Fileds  ::

        [JsonProperty("Head")]
        public Head head { get; set; }

        [JsonProperty("Body")]
        public Body2 body { get; set; }

        #endregion

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

        public double E_Day
        {
            get
            {
                return body.site.E_Day;
            }
        }

        public double E_Year
        {
            get
            {
                return body.site.E_Year;
            }
        }

        public double E_Total
        {
            get
            {
                return body.site.E_Total;
            }
        }

        public Production2()
        {
            head = new Head();
            body = new Body2();
        }
    }
}
