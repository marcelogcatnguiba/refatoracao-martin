using System.Text.Json.Serialization;

namespace Refactor.Domain.Entities;

public class Invoices
{
    [JsonPropertyName("customer")]
    public string Customer { get; set; } = string.Empty;

    [JsonPropertyName("performances")]
    public List<Performances> Performances { get; set; } = [];
}
