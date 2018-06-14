using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar
{
    public class Head
    {
        /// <summary>
        /// Repetition of the parameters which produced this response.
        /// Filled with properties named like the given parameters.
        /// </summary>
        public RequestArguments requestArguments { get; set; }

        /// <summary>
        /// Information about the response.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// RFC3339 timestamp in localtime of the datalogger.
        /// This is the time the request was answered - NOT the time when the data was queried from the device.
        /// </summary>
        public string Timestamp { get; set; }
}
}
