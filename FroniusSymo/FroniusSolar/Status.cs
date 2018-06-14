using Newtonsoft.Json;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Status
    {
        /// <summary>
        /// Indicates if the request went OK or gives a hint about what went wrong.
        /// 0 means OK , any other value means something went wrong (e.g. Device not available ,
        /// invalid params , no data in logflash for given time , ...).
        /// </summary>
        [JsonProperty("Code")]
        public int Code { get; set; }

        /// <summary>
        /// Error message , may be empty.
        /// </summary>
        [JsonProperty("Reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Error message to be displayed to the user , may be empty.
        /// </summary>
        [JsonProperty("UserMessage")]
        public string UserMessage { get; set; }

        //[JsonProperty("Code")]
        // public ErrorDetail errorDetail { get; set; } //do zdefiniowania
    }
}