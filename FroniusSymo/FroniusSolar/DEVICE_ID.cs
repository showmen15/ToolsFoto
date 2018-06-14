namespace FroniusSymo.FroniusSolar
{
    public class DEVICE_ID
    {
        /// <summary>
        /// Optional Nodetype if localnet node
        /// </summary>
        public int NodeType { get; set; }

        /// <summary>
        /// Optional Devicetype if localnet node
        /// </summary>
        public int DeviceType { get; set; }

        /// <summary>
        /// Starting date of the series (i.e. date of the first value in Values)
        /// yyyy -MM -ddThh -mm -ss%z "2017 -05 -20 T00 :00:00+02:00"
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Starting date of the series (i.e. date of the first value in Values)
        /// yyyy -MM -ddThh -mm -ss%z "2017 -05 -20 T23 :59:59+02:00"
        /// </summary>
        public string End { get; set; }


        /// <summary>
        /// # Collection of objects representing one channel , each object containing values and metadata.
        /// Objects are named after the Channel they represent (e.g. "Power ").
        /// </summary>
        public DataValues dataValue { get; set; }
    }
}