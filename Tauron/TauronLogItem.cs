using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tauron
{
    public class TauronLogItem
    {
        public DateTime InsertTimeStamp { get; set; }

        public DateTime InsertDate
        {
            get
            {
                return InsertTimeStamp.Date;
            }
        }

        public double PowerConsumption { get; set; }

        public double PowerProduction { get; set; }

        public double CurrentTemperature { get; set; }

        public TauronLogItem()
        {

        }

        public static TauronLogItem FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            TauronLogItem tauronLogItemValues = new TauronLogItem();
            tauronLogItemValues.InsertTimeStamp = Convert.ToDateTime(values[0]);
            tauronLogItemValues.PowerConsumption = Convert.ToDouble(values[1]);
            tauronLogItemValues.PowerProduction = Convert.ToDouble(values[2]);

            return tauronLogItemValues;
        }

    }
}
