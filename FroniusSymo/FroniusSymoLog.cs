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


        public void DeserializeJosn()
        {
        /*    string file22 = @"D:\drop\Dropbox\Solar\test.txt";

            string input11 = File.ReadAllText(file22);

            JsonTextReader reader = new JsonTextReader(new StreamReader(file22));

            while (reader.Read())
            {
                if (reader.Value != null)
                    ;
            }
        

                    // Object resulet777 = JsonConvert.DeserializeObject(input11);


                    // List<Values> tt = new List<Values>();
                    // tt.Add(new Values() { key = "22", value = 22.3 });
                    // tt.Add(new Values() { key = "33", value = 22.3 });

                    //string www2 = JsonConvert.SerializeObject(tt, Newtonsoft.Json.Formatting.Indented);


                    // DuplicateDictionary<string, double> values = new DuplicateDictionary<string, double>();

                    KeyValuePair<string, double>[] values = new KeyValuePair<string, double>[] { new KeyValuePair<string, double>("222", 22.3), new KeyValuePair<string, double>("222", 22.33) };
                    

            string www2 = JsonConvert.SerializeObject(values, Newtonsoft.Json.Formatting.Indented);
            */

            string file123 = @"D:\drop\Dropbox\Solar\Nowy dokument tekstowy.json";

           

            string test = File.ReadAllText(file123);
           var  word = Regex.Match(test, @"""Values""\s:\s{(.*?)}", RegexOptions.Singleline);
          
            
            //  Console.WriteLine(word);


            /*   MyType<string, int> testowy = new MyType<string, int>();
               testowy.Add("333", 5544);
               testowy.Add("333", 5544);

               string www2 = JsonConvert.SerializeObject(testowy, Newtonsoft.Json.Formatting.Indented);
               */

            /*   string file1 = @"D:\drop\Dropbox\Solar\Nowy dokument tekstowy.json";

            string input1 = File.ReadAllText(file1);



            object JsonDe = JsonConvert.DeserializeObject(input1);

            /*   DuplicateDictionary<string, double> test = new DuplicateDictionary<string, double>();
            test.Add("aaa", 222);
            test.Add("aaa", 222);

            string www2 = JsonConvert.SerializeObject(test, Newtonsoft.Json.Formatting.Indented);
            */

            /*   MyType ooo = new MyType();
               ooo.Key = "22";
               ooo.Value = 33.44;

               List<MyType> ttt = new List<MyType>();
               ttt.Add(ooo);
               ttt.Add(ooo);


               string www2 = JsonConvert.SerializeObject(ttt, Newtonsoft.Json.Formatting.Indented);

               FroniusSolar.MyJsonDictionary<string, int> ss = new MyJsonDictionary<string, int>();

               ss.Add("2222", 2222);
               //ss.Add("2222", 22221);

               string www = JsonConvert.SerializeObject(ss, Newtonsoft.Json.Formatting.Indented);


               // string file = @"C:\Users\szsz\Dropbox\Solar\Nowy dokument tekstowy.json";

          */

            string file = @"D:\drop\Dropbox\Solar\Nowy dokument tekstowy.json";

             string input = File.ReadAllText(file);

 

             FroniusSolarResponses resulet = JsonConvert.DeserializeObject<FroniusSolarResponses>(input);




          //  CHANNEL_NAME test = new CHANNEL_NAME();

           string outt = JsonConvert.SerializeObject(resulet, Newtonsoft.Json.Formatting.Indented);

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
