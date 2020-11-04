using Newtonsoft.Json;

namespace EmailService.Models
{
    public class JokeTemplate
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("joke")]
        public string Joke { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

    }
}
