using System.Xml.Serialization;

namespace FroniusSymo.SunSpec
{
    public class DataPointRecord
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlText]
        public string DescriptionDataPointRecord { get; set; }

        public DataPointRecord ()
        {
        }
    }
}