using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FroniusSymo.SunSpec
{

    public class Properties
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlElement]
        public string Value { get; set; }
    }
}
