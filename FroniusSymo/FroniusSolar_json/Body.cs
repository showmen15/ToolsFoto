using Newtonsoft.Json;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Body
    {
        /// <summary>
        /// Object with dataseries for each requested device.
        /// Property names correspond to the DeviceId the series belongs to.
        /// </summary>
        [JsonProperty("Data")]
        public Data data { get; set; }

    }
}