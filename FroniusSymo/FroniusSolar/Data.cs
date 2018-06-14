using Newtonsoft.Json;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Data
    {
        /// <summary>
        /// Object representing data -series of one device (may contain more than one channel).
        /// </summary>
        [JsonProperty(@"inverter")]
        public DEVICE_ID deviceID { get; set; }

    }
}