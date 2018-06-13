using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tauron
{
    public class TauronLog
    {



        public TauronLog()
        {

        }

        public IEnumerable<TauronLogItem> GetTauronLogData(string sFileName)
        {
            List<TauronLogItem> result = new List<TauronLogItem>();

            string sConnetionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 12.0; IMEX=1; HDR=YES; TypeGuessRows=0; ImportMixedTypes=Text'", sFileName);

            using (OleDbConnection conn = new OleDbConnection(sConnetionString))
            {
                conn.Open();

                using (OleDbCommand cmd = new OleDbCommand("", conn))
                {
                    cmd.CommandText = "SELECT * FROM [Dane$]";

                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        DateTime LastDateTime = DateTime.Now;

                        while (rdr.Read())
                        {
                            TauronLogItem temp = new TauronLogItem();

                            temp.InsertTimeStamp = LastDateTime = parseExact24h(rdr[0].ToString(), LastDateTime);

                            if (!string.IsNullOrWhiteSpace(rdr[1].ToString()))
                                temp.PowerConsumption = double.Parse(rdr[1].ToString());

                            if (!string.IsNullOrWhiteSpace(rdr[2].ToString()))
                                temp.PowerProduction = double.Parse(rdr[2].ToString());

                            if (!string.IsNullOrWhiteSpace(rdr[3].ToString()))
                                temp.CurrentTemperature = double.Parse(rdr[3].ToString());

                            result.Add(temp);
                        }
                    }
                }
            }

            return result;
        }

        private DateTime parseExact24h(string input, DateTime lastDateTime)
        {
            DateTime result;

            if(input.Length <= 2)
            {
                int hour = int.Parse(input);

                if (hour == 24)
                    hour = 0;

                result = new DateTime(lastDateTime.Year, lastDateTime.Month, lastDateTime.Day, hour, 0, 0);
            }
            else
            {
                CultureInfo provider = CultureInfo.GetCultureInfo("en-US");
                result = DateTime.ParseExact(input, "yyyy-MM-dd h", provider);
            }

            return result;
        }
    }
}
