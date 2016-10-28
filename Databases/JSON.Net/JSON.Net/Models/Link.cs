
using Newtonsoft.Json;

namespace JSON.Net.Models
{
    public class Link
    {
        [JsonProperty("@href")]
        public string Href { get; set; }

        [JsonProperty("@rel")]
        public string Rel { get; set; }
    }
}
