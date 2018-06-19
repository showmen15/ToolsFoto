using Newtonsoft.Json;

namespace FroniusSymo.FroniusSolar
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Values
    {
        public string key { get; set; }

        public double value { get; set; }

    }
}