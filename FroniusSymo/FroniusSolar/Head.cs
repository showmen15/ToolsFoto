using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Head
    {
        /// <summary>
        /// Repetition of the parameters which produced this response.
        /// Filled with properties named like the given parameters.
        /// </summary>
        [JsonProperty("RequestArguments")]
        public RequestArguments requestArguments { get; set; }

        /// <summary>
        /// Information about the response.
        /// </summary>
        [JsonProperty("Status")]
        public Status status { get; set; }

        /// <summary>
        /// RFC3339 timestamp in localtime of the datalogger.
        /// This is the time the request was answered - NOT the time when the data was queried from the device.
        /// </summary>
        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }
}
}
