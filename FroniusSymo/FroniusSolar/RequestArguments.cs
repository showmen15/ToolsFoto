using System.Collections.Generic;

namespace FroniusSymo.FroniusSolar
{
    public class RequestArguments
    {

        public string Scope { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public List<string> Channel { get; set; }

        public string SeriesType { get; set; }

        public string HumanReadable { get; set; }


        public string DeviceId { get; set; }

        public string DataCollection { get; set; }

    }
}