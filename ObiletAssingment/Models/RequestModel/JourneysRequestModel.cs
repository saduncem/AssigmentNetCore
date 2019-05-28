using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletAssingment.Models
{
    public class JourneysRequestModel
    {
        [JsonProperty("device-session")]
        public DeviceSession device_session { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }

        [JsonProperty("data")]
        public Data data { get; set; }

    }
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }

    public class Data
    {
        [JsonProperty("origin-id")]
        public int origin_id { get; set; }

        [JsonProperty("destination-id")]
        public int destination_id { get; set; }

        [JsonProperty("departure-date")]
        public string departure_date { get; set; }
    }
}
