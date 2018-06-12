using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FroniusSymo.SunSpec
{
    [XmlRoot("SunSpecData")]
    public class SunSpecData
    {
        [XmlAttribute("v")]
        public string v { get; set; }

        [XmlElement("d")]
        public SpecData specData  { get; set; }

        public SunSpecData()
        {
            specData = new SpecData();
        }
    }
}
