using System.Text.Json.Serialization;

namespace protracker_parser.Models
{
    public class Hero
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("localized_name")]
        public string? Name { get; set; }

        
    }
}
