using System.Text.Json.Serialization;

namespace Refactor.Domain.Entities;

public class Invoices
{
    [JsonPropertyName("customer")]
    public required string Customer { get; set; }

    [JsonPropertyName("performances")]
    public required List<Performances> Performances { get; set; }
}
