using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletAssingment.Models.RequestModel
{
    public class SessionRequestModel
    {
        [JsonProperty("type")]
        public int type { get; set; }
        [JsonProperty("connection")]
        public Connection connection { get; set; }
        [JsonProperty("browser")]
        public Browser browser { get; set; }

        public class Connection
        {
            [JsonProperty("ip-address")]
            public string ip_address { get; set; }
            [JsonProperty("port")]
            public string port { get; set; }
        }

        public class Browser
        {
            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("version")]
            public string version { get; set; }
        }


    }
}
