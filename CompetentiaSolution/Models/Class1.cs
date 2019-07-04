using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace CompetentiaSolution.Models
{
    public class Class1
    {
    }
    public partial class Welcome
    {
        [JsonProperty("greeting")]
        public string Greeting { get; set; }

        [JsonProperty("instructions")]
        public string[] Instructions { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}