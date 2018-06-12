using System.Collections.Generic;
using System.Xml.Serialization;

namespace FroniusSymo.SunSpec
{
    public class ModelRecord
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlElement("p")]
        public List<DataPointRecord> dataPointRecord { get; set; }

        public ModelRecord()
        {
        }
    }
}