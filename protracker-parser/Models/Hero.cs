using System.Text.Json.Serialization;

namespace protracker_parser.Models
{
    public class Hero
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("localized_name")]
        public string? Name { get; set; }


        [JsonPropertyName("pub_pick")]
        public int PubPicks { get; set; }

        [JsonPropertyName("pub_win")]
        public int PubWins { get; set; }


        [JsonPropertyName("turbo_picks")]
        public int TurboPicks { get; set; }

        [JsonPropertyName("turbo_wins")]
        public int TurboWins { get; set; }

        [JsonPropertyName("img")]
        public string? ImgPath { get; set; }

    }
}
