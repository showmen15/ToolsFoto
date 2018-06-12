﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FroniusSymo.SunSpec
{
    /// <summary>
    /// http://sunspec.org/wp-content/uploads/2015/06/SunSpec-Model-Data-Exchange-12021.pdf
    /// </summary>
    [XmlRoot("SunSpecData")]
    public class SunSpecData
    {
        [XmlAttribute("v")]
        public string v { get; set; }

        [XmlElement("d")]
        public DeviceRecord deviceRecord { get; set; }
       
        public SunSpecData()
        {
            deviceRecord = new DeviceRecord();
        }

        [XmlIgnore]
        public DateTime? Timestamp
        {
            get
            {
                DateTime result;

                if (deviceRecord != null && DateTime.TryParse(deviceRecord.t, out result))
                    return result;
                else
                    return null;               
            }
        }

        [XmlIgnore]
        public string W
        {
            get
            {
                return getDescriptionDataPointRecord("113", "W");
            }
        }

        [XmlIgnore]
        public string Wh
        {
            get
            {
                return getDescriptionDataPointRecord("113", "Wh");
            }
        }

        private string getDescriptionDataPointRecord(string modulRecordsID, string dataPointRecordID)
        {
            string result = string.Empty;

            if (deviceRecord != null && deviceRecord.modulRecords != null)
            {
                ModelRecord tempModelRecord = deviceRecord.modulRecords.Find(x => x.id == modulRecordsID);

                if (tempModelRecord != null && tempModelRecord.dataPointRecord != null)
                    result = tempModelRecord.dataPointRecord.Find(p => p.id == dataPointRecordID).DescriptionDataPointRecord;
            }

            return result;
        }
    }
}
