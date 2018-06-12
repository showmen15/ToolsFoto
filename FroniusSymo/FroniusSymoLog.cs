using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FroniusSymo.Common;
using FroniusSymo.Production;
using FroniusSymo.Production2;
using FroniusSymo.SunSpec;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace FroniusSymo
{
    public class FroniusSymoLog
    {
        public FroniusSymoLog()
        {
        }

        public IEnumerable<SunSpecData> GetSunSpecData(string sDirectoryPath)
        {
            List<SunSpecData> result = new List<SunSpecData>();
            string[] inputs = Directory.GetFiles(sDirectoryPath, "SunSpec*");

            foreach (var file in inputs)
            {
                SunSpecData tempSunSpecDate;

                using (StreamReader rdr = new StreamReader(file, false))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SunSpecData));
                    tempSunSpecDate = (SunSpecData)serializer.Deserialize(rdr);
                }

                if (tempSunSpecDate.ExistWhAndW)
                    result.Add(tempSunSpecDate);
            }

            return result;
        }

        public IEnumerable<Production2.Production2> GetProduction2(string sDirectoryPath)
        {
            List<Production2.Production2> result = new List<Production2.Production2>();
            string[] inputs = Directory.GetFiles(sDirectoryPath, "SolarAPI_CurrentData_PowerFlow*");

            foreach (var file in inputs)
            {
                string input = File.ReadAllText(file);

                if (!string.IsNullOrWhiteSpace(input))
                    result.Add(JsonConvert.DeserializeObject<Production2.Production2>(input));
            }

            return result;
        }

        public IEnumerable<Production.Production> GetProduction(string sDirectoryPath)
        {
            List<Production.Production> result = new List<Production.Production>();
            string[] inputs = Directory.GetFiles(sDirectoryPath, "SolarApiCurrentInverter*");

            foreach (var file in inputs)
            {
                string input = File.ReadAllText(file);

                if (!string.IsNullOrWhiteSpace(input))
                    result.Add(JsonConvert.DeserializeObject<Production.Production>(input));
            }

            return result;
        }
    }
}
