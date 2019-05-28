using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletAssingment.Models.RequestModel
{
    public class BuslocationsRequestModel
    {
        [JsonProperty("data")]
        public object data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession device_session { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }


        public class DeviceSession
        {
            [JsonProperty("session-id")]
            public string session_id { get; set; }
            [JsonProperty("device-id")]
            public string device_id { get; set; }
        }
    }
}
