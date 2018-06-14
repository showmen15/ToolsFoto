using Newtonsoft.Json;
using System.Collections.Generic;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RequestArguments
    {
        [JsonProperty("Scope")]
        public string Scope { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("Channel")]
        public string Channel { get; set; }

        [JsonProperty("SeriesType")]
        public string SeriesType { get; set; }

        [JsonProperty("HumanReadable")]
        public string HumanReadable { get; set; }

        //[JsonProperty("RequestArguments")]
        //public string DeviceId { get; set; }

        //[JsonProperty("RequestArguments")]
        //public string DataCollection { get; set; }

    }
}