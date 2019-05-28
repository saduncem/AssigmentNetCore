using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletAssingment.Models
{
    public class JourneysResponseModel
    {
        public string status { get; set; }
        public IList<Journeysdata> data { get; set; }
        public class Stop
        {

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("station")]
            public string station { get; set; }

            [JsonProperty("time")]
            public string time { get; set; }

            [JsonProperty("is-origin")]
            public bool? is_origin { get; set; }

            [JsonProperty("is-destinatio")]
            public bool? is_destination { get; set; }
        }

        public class Policy
        {
            [JsonProperty("max_seats")]
            public object max_seats { get; set; }

            [JsonProperty("max_single")]
            public object max_single { get; set; }

            [JsonProperty("max_single_males")]
            public object max_single_males { get; set; }

            [JsonProperty("max_single_females")]
            public object max_single_females { get; set; }

            [JsonProperty("mixed_genders")]
            public bool? mixed_genders { get; set; }

            [JsonProperty("gov_id")]
            public bool? gov_id { get; set; }

            [JsonProperty("lht")]
            public bool? lht { get; set; }
        }

        public class Journey
        {

            [JsonProperty("kind")]
            public string kind { get; set; }


            [JsonProperty("code")]
            public string code { get; set; }

            [JsonProperty("stops")]
            public IList<Stop> stops { get; set; }

            [JsonProperty("origin")]
            public string origin { get; set; }

            [JsonProperty("destination")]
            public string destination { get; set; }

            [JsonProperty("departure")]
            public DateTime? departure { get; set; }

            [JsonProperty("arrival")]
            public DateTime? arrival { get; set; }


            [JsonProperty("currency")]
            public string currency { get; set; }

            [JsonProperty("duration")]
            public string duration { get; set; }

            [JsonProperty("original-price")]
            public double? original_price { get; set; }

            [JsonProperty("internet-price")]
            public double? internet_price { get; set; }

            [JsonProperty("booking")]
            public object booking { get; set; }

            [JsonProperty("bus-name")]
            public string bus_name { get; set; }

            [JsonProperty("policy")]
            public Policy policy { get; set; }

            [JsonProperty("features")]
            public IList<string> features { get; set; }

            [JsonProperty("description")]
            public object description { get; set; }

            [JsonProperty("available")]
            public object available { get; set; }
        }

        public class Feature
        {
            [JsonProperty("id")]
            public int? id { get; set; }

            [JsonProperty("priority")]
            public int? priority { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("description")]
            public object description { get; set; }

            [JsonProperty("is-promoted")]
            public bool? is_promoted { get; set; }
            [JsonProperty("back-color")]
            public object back_color { get; set; }

            [JsonProperty("fore-color")]
            public object fore_color { get; set; }
        }

        public class Journeysdata
        {

            [JsonProperty("id")]
            public int? id { get; set; }

            [JsonProperty("partner-id")]
            public int? partner_id { get; set; }

            [JsonProperty("partner-name")]
            public string partner_name { get; set; }

            [JsonProperty("route-id")]
            public int? route_id { get; set; }

            [JsonProperty("bus-type")]
            public string bus_type { get; set; }

            [JsonProperty("bus-type-name")]
            public string bus_type_name { get; set; }

            [JsonProperty("total-seats")]
            public int? total_seats { get; set; }

            [JsonProperty("available-seats")]
            public int? available_seats { get; set; }


            [JsonProperty("journey")]
            public Journey journey { get; set; }

            [JsonProperty("features")]
            public IList<Feature> features { get; set; }

            [JsonProperty("origin-location")]
            public string origin_location { get; set; }

            [JsonProperty("destination-location")]
            public string destination_location { get; set; }

            [JsonProperty("is-active")]
            public bool? is_active { get; set; }

            [JsonProperty("origin-location-id")]
            public int? origin_location_id { get; set; }

            [JsonProperty("destination-location-id")]
            public int destination_location_id { get; set; }

            [JsonProperty("is-promoted")]
            public bool? is_promoted { get; set; }
            [JsonProperty("cancellation-offset")]
            public int? cancellation_offset { get; set; }

            [JsonProperty("has-bus-shuttle")]
            public bool? has_bus_shuttle { get; set; }

            [JsonProperty("disable-sales_without-gov-id")]
            public bool disable_sales_without_gov_id { get; set; }

            [JsonProperty("display-offset")]
            public object display_offset { get; set; }


            [JsonProperty("partner-rating")]
            public double? partner_rating { get; set; }

            [JsonProperty("hasdynamic-pricing")]
            public bool? has_dynamic_pricing { get; set; }
        }
    }
}
