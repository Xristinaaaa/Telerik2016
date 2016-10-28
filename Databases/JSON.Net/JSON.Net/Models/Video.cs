using Newtonsoft.Json;

namespace JSON.Net.Models
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("videoId")]
        public string Id { get; set; }
    }
}
