using ChimpAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChimpAPI.Core.JsonObjects
{
    public class Members
    {
        public class MembersList
        {
            [JsonProperty("members")]
            public Member[] Members { get; set; }

            [JsonProperty("list_id")]
            public string ListId { get; set; }

            [JsonProperty("total_items")]
            public long TotalItems { get; set; }

            [JsonProperty("_links")]
            public Link[] Links { get; set; }
        }

        public class Link
        {
            [JsonProperty("rel")]
            public string Rel { get; set; }

            [JsonProperty("href")]
            public Uri Href { get; set; }

            [JsonProperty("method")]
            public Method Method { get; set; }

            [JsonProperty("targetSchema", NullValueHandling = NullValueHandling.Ignore)]
            public Uri TargetSchema { get; set; }

            [JsonProperty("schema", NullValueHandling = NullValueHandling.Ignore)]
            public Uri Schema { get; set; }
        }

        public  class Member
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("email_address")]
            public string EmailAddress { get; set; }

            [JsonProperty("unique_email_id")]
            public string UniqueEmailId { get; set; }

            [JsonProperty("web_id")]
            public long WebId { get; set; }

            [JsonProperty("email_type")]
            public string EmailType { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("merge_fields")]
            public MergeFields MergeFields { get; set; }

            [JsonProperty("stats")]
            public Stats Stats { get; set; }

            [JsonProperty("ip_signup")]
            public string IpSignup { get; set; }

            [JsonProperty("timestamp_signup")]
            public string TimestampSignup { get; set; }

            [JsonProperty("ip_opt")]
            public string IpOpt { get; set; }

            [JsonProperty("timestamp_opt")]
            public DateTimeOffset TimestampOpt { get; set; }

            [JsonProperty("member_rating")]
            public long MemberRating { get; set; }

            [JsonProperty("last_changed")]
            public DateTimeOffset LastChanged { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("vip")]
            public bool Vip { get; set; }

            [JsonProperty("email_client")]
            public string EmailClient { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("tags_count")]
            public long TagsCount { get; set; }

            [JsonProperty("tags")]
            public object[] Tags { get; set; }

            [JsonProperty("list_id")]
            public string ListId { get; set; }

            [JsonProperty("_links")]
            public Link[] Links { get; set; }

            [JsonProperty("unsubscribe_reason", NullValueHandling = NullValueHandling.Ignore)]
            public string UnsubscribeReason { get; set; }
        }

        public  class Location
        {
            [JsonProperty("latitude")]
            public long Latitude { get; set; }

            [JsonProperty("longitude")]
            public long Longitude { get; set; }

            [JsonProperty("gmtoff")]
            public long Gmtoff { get; set; }

            [JsonProperty("dstoff")]
            public long Dstoff { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("timezone")]
            public string Timezone { get; set; }
        }

        public  class MergeFields
        {
            [JsonProperty("FNAME")]
            public string Fname { get; set; }

            [JsonProperty("LNAME")]
            public string Lname { get; set; }

            [JsonProperty("ADDRESS")]
            public Address Address { get; set; }

            [JsonProperty("PHONE")]
            public string Phone { get; set; }

            [JsonProperty("BIRTHDAY")]
            public string Birthday { get; set; }
        }

        public  class Address
        {
            [JsonProperty("addr1")]
            public string Addr1 { get; set; }

            [JsonProperty("addr2")]
            public string Addr2 { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("zip")]
            public string Zip { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }
        }

        public  class Stats
        {
            [JsonProperty("avg_open_rate")]
            public long AvgOpenRate { get; set; }

            [JsonProperty("avg_click_rate")]
            public long AvgClickRate { get; set; }
        }
    }
}
