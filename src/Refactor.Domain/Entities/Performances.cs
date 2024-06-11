using System.Text.Json.Serialization;

namespace Refactor.Domain.Entities;

public class Performances
{
    [JsonPropertyName("playID")]
    public string PlayId { get; set; } = string.Empty;

    [JsonPropertyName("audience")]
    public int Audience { get; set; }
}
