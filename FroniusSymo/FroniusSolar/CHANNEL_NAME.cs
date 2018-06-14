namespace FroniusSymo.FroniusSolar
{
    public class CHANNEL_NAME
    {
        /// <summary>
        /// Baseunit of the channel , never contains any prefixes
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Unscaled values , offset between datapoints can be deduced through "SeriesType"
        /// ATTENTION: Unavailable datapoints are included but have value null
        /// NOTE: the data records are listed in alphabetical order
        /// example: "3600" : 10.11 .... offset is 3600 sec and value is 10.11
        /// </summary>
        public int offsetInSecond;
    }
}