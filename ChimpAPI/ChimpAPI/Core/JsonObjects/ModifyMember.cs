using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpAPI.Core.JsonObjects
{
    public class ModifyMember
    {
        public partial class Member
        {
            [JsonProperty("email_address")]
            public string EmailAddress { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("merge_fields")]
            public MergeFields MergeFields { get; set; }
        }

        public partial class MergeFields
        {
            [JsonProperty("FNAME")]
            public string Fname { get; set; }

            [JsonProperty("LNAME")]
            public string Lname { get; set; }
        }
    }
}
