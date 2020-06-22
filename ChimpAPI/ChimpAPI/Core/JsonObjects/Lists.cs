using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static ChimpAPI.Utils.Parser;

namespace ChimpAPI.Core.JsonObjects
{
    public class Lists
    {      
        public class ListObjects
        {
            [JsonProperty("lists")]
            public List[] Lists { get; set; }

            [JsonProperty("total_items")]
            public long TotalItems { get; set; }
        }

        #region JsonClasses
        private class Constraints
        {
            [JsonProperty("may_create")]
            public bool MayCreate { get; set; }

            [JsonProperty("max_instances")]
            public long MaxInstances { get; set; }

            [JsonProperty("current_total_instances")]
            public long CurrentTotalInstances { get; set; }
        }

     

        public class List
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("web_id")]
            public long WebId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("contact")]
            public Contact Contact { get; set; }

            [JsonProperty("permission_reminder")]
            public string PermissionReminder { get; set; }

            [JsonProperty("use_archive_bar")]
            public bool UseArchiveBar { get; set; }

            [JsonProperty("campaign_defaults")]
            public CampaignDefaults CampaignDefaults { get; set; }

            [JsonProperty("notify_on_subscribe")]
            public string NotifyOnSubscribe { get; set; }

            [JsonProperty("notify_on_unsubscribe")]
            public string NotifyOnUnsubscribe { get; set; }

            [JsonProperty("date_created")]
            public DateTimeOffset DateCreated { get; set; }

            [JsonProperty("list_rating")]
            public long ListRating { get; set; }

            [JsonProperty("email_type_option")]
            public bool EmailTypeOption { get; set; }

            [JsonProperty("subscribe_url_short")]
            public Uri SubscribeUrlShort { get; set; }

            [JsonProperty("subscribe_url_long")]
            public Uri SubscribeUrlLong { get; set; }

            [JsonProperty("beamer_address")]
            public string BeamerAddress { get; set; }

            [JsonProperty("visibility")]
            public string Visibility { get; set; }

            [JsonProperty("double_optin")]
            public bool DoubleOptin { get; set; }

            [JsonProperty("has_welcome")]
            public bool HasWelcome { get; set; }

            [JsonProperty("marketing_permissions")]
            public bool MarketingPermissions { get; set; }

            [JsonProperty("modules")]
            public object[] Modules { get; set; }

            [JsonProperty("stats")]
            public Stats Stats { get; set; }

         
        }

        public class CampaignDefaults
        {
            [JsonProperty("from_name")]
            public string FromName { get; set; }

            [JsonProperty("from_email")]
            public string FromEmail { get; set; }

            [JsonProperty("subject")]
            public string Subject { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }
        }

        public class Contact
        {
            [JsonProperty("company")]
            public string Company { get; set; }

            [JsonProperty("address1")]
            public string Address1 { get; set; }

            [JsonProperty("address2")]
            public string Address2 { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("zip")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Zip { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }
        }

        public class Stats
        {
            [JsonProperty("member_count")]
            public long MemberCount { get; set; }

            [JsonProperty("unsubscribe_count")]
            public long UnsubscribeCount { get; set; }

            [JsonProperty("cleaned_count")]
            public long CleanedCount { get; set; }

            [JsonProperty("member_count_since_send")]
            public long MemberCountSinceSend { get; set; }

            [JsonProperty("unsubscribe_count_since_send")]
            public long UnsubscribeCountSinceSend { get; set; }

            [JsonProperty("cleaned_count_since_send")]
            public long CleanedCountSinceSend { get; set; }

            [JsonProperty("campaign_count")]
            public long CampaignCount { get; set; }

            [JsonProperty("campaign_last_sent")]
            public string CampaignLastSent { get; set; }

            [JsonProperty("merge_field_count")]
            public long MergeFieldCount { get; set; }

            [JsonProperty("avg_sub_rate")]
            public long AvgSubRate { get; set; }

            [JsonProperty("avg_unsub_rate")]
            public long AvgUnsubRate { get; set; }

            [JsonProperty("target_sub_rate")]
            public long TargetSubRate { get; set; }

            [JsonProperty("open_rate")]
            public long OpenRate { get; set; }

            [JsonProperty("click_rate")]
            public long ClickRate { get; set; }

            [JsonProperty("last_sub_date")]
            public DateTimeOffset LastSubDate { get; set; }

            [JsonProperty("last_unsub_date")]
            public DateTimeOffset LastUnsubDate { get; set; }
        }
        #endregion        
    }
}
