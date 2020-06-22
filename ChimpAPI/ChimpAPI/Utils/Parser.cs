using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpAPI.Utils
{
    
    /// <summary>
    /// Handles Json Parsing
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Converts Json to Object
        /// </summary>
        /// <typeparam name="T">Class to parse into</typeparam>
        /// <param name="json">Json Data</param>
        /// <returns></returns>
        public static T Convert<T>(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
        
        internal class MethodConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Method) || t == typeof(Method?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "DELETE":
                        return Method.Delete;
                    case "GET":
                        return Method.Get;
                    case "PATCH":
                        return Method.Patch;
                    case "POST":
                        return Method.Post;
                    case "PUT":
                        return Method.Put;
                }
                Logger.Log("Cannot unmarshal type Method", Logger.Severity.Error);
                return null;
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Method)untypedValue;
                switch (value)
                {
                    case Method.Delete:
                        serializer.Serialize(writer, "DELETE");
                        return;
                    case Method.Get:
                        serializer.Serialize(writer, "GET");
                        return;
                    case Method.Patch:
                        serializer.Serialize(writer, "PATCH");
                        return;
                    case Method.Post:
                        serializer.Serialize(writer, "POST");
                        return;
                }
                Logger.Log("Cannot marshal type Method", Logger.Severity.Error);
            }

            public static readonly MethodConverter Singleton = new MethodConverter();
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                Logger.Log("Cannot unmarshal type long", Logger.Severity.Error);
                return false;
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    MethodConverter.Singleton,
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }


    public enum Method { Delete, Get, Patch, Post, Put };
}
