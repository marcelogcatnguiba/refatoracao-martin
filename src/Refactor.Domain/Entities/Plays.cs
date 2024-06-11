using System.Text.Json.Serialization;

namespace Refactor.Domain.Entities
{
    public class Plays
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
    }
}