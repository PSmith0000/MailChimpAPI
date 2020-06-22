using System;
namespace ChimpAPI.Core
{
    class Command
    {
        public Command(string HttpMethod, string requestUri, Type JsonObj, string ID = null, object Content = null)
        {
            httpMethod = HttpMethod;
            RequestUri = requestUri;
            JsonType = JsonObj;
            iD = ID;
            
        }
        internal string httpMethod { get; set; }
        internal string RequestUri { get; set; }
        internal Type JsonType { get; set; }
        internal string iD { get; set; }
        internal object data { get; set; }
        internal T Execute<T>()
        {
            var r = Network.MakeRequest(Config.API_KEY, Config.SERVER, RequestUri, JsonType, httpMethod, data).Content.ReadAsStringAsync().Result;
            if (JsonType == typeof(JsonObjects.Lists.ListObjects))
            {
                return (T)Convert.ChangeType(Utils.Parser.Convert<JsonObjects.Lists.ListObjects>(r), JsonType);
            }
            else if (JsonType == typeof(JsonObjects.Members.MembersList))
            {
                return (T)Convert.ChangeType(Utils.Parser.Convert<JsonObjects.Members.MembersList>(r), JsonType);
            }
            return (T)Convert.ChangeType(true, typeof(bool));
        }

        
    }
}
