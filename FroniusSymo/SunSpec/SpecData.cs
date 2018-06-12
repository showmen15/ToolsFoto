using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FroniusSymo.SunSpec
{
    public class SpecData
    {
        [XmlAttribute("man")]
        public string man { get; set; }

        [XmlAttribute("mod")]
        public string mod { get; set; }

        [XmlAttribute("sn")]
        public string sn { get; set; }

        [XmlAttribute("t")]
        public string t { get; set; }

        public DateTime? dateTime
        {
            get
            {
                DateTime temp;

                if (DateTime.TryParse(t, out temp))
                    return temp;
                else
                    return null;
            }
        }
   }
}
