using Newtonsoft.Json;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DataValues
    {
        /// <summary>
        /// Object representing one channel.
        /// </summary>
        [JsonProperty("EnergyReal_WAC_Sum_Produced")]
        public EnergyReal_WAC_Sum_Produced channelName { get; set; }  //Typ generyczny moze sie rownic w zaleznosci od zapytania

    }
}