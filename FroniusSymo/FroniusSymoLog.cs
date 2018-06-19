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
using FroniusSymo.FroniusSolar;
using System.Text.RegularExpressions;
using System.Net;

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

        public double DailySumProduction(DateTime date)
        {
            double result = 0.0;

            string input = getResponseFromProduction(date);         

            result = getSecondProduction(input);

            return result;
        }

        private double getSecondProduction(string sJSONProduction)
        {
            double result = 0.0;

            string prod = Regex.Match(sJSONProduction, @"""Values""\s:\s{(.*?)}", RegexOptions.Singleline).Groups[0].Value;

            prod = prod.Replace("\"Values\" : {", string.Empty);
            prod = prod.Replace("{", string.Empty);
            prod = prod.Replace("}", string.Empty);

            prod = prod.Replace(":", ",");

            string[] splited = prod.Split(',');

            for(int i = 1; i< splited.Length; i = i + 2)
            {
                string split = splited[i].Replace(".", ",");

                result += double.Parse(split);
            }

            return result;
        }

        private string getResponseFromProduction(DateTime date)
        {
            string result = string.Empty;
            string sIP = "192.168.2.100";
            string sDate = date.ToString("dd.MM.yyyy");

            string url = string.Format("http://{0}/solar_api/v1/GetArchiveData.cgi?Scope=Device&DeviceClass=Inverter&DeviceId=1&StartDate={1}&EndDate={1}&Channel=EnergyReal_WAC_Sum_Produced&HumanReadable=True", sIP, sDate);

            WebRequest request = WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
