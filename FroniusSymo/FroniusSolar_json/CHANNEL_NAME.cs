using Newtonsoft.Json;
using System.Collections.Generic;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EnergyReal_WAC_Sum_Produced
    {
        [JsonProperty("_comment")]
        public string _comment { get; set; }

        /// <summary>
        /// Baseunit of the channel , never contains any prefixes
        /// </summary>
        [JsonProperty("Unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Unscaled values , offset between datapoints can be deduced through "SeriesType"
        /// ATTENTION: Unavailable datapoints are included but have value null
        /// NOTE: the data records are listed in alphabetical order
        /// example: "3600" : 10.11 .... offset is 3600 sec and value is 10.11
        /// </summary>
        //[JsonContainer]
        //public KeyValuePair<string, double>[] values { get; set; }
        //public List<List<KeyValuePair<string, double>>> values { get; set; }

        [JsonProperty("Values")]
        public object values { get; set; }

        //MyJsonDictionary<string, double> values { get; set; }

        //DuplicateDictionary<string,double> values { get; set; }

        //MyJsonDictionary<string, double> values { get; set; }
        // List<string> values { get; set; }

        public EnergyReal_WAC_Sum_Produced()
        {
          //  values.

           /* Unit = "W";
           /* offsetInSecond = new Dictionary<string, double>();
            offsetInSecond.Add("22", 0.22);
            offsetInSecond.Add("11", 0.222);
            */
        }
    }
}