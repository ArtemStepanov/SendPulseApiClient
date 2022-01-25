using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Response;

public class AddressBookResponse
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("all_email_qty")]
    public long AllEmailQuantity { get; set; }

    [JsonPropertyName("active_email_qty")]
    public long ActiveEmailQuantity { get; set; }

    [JsonPropertyName("inactive_email_qty")]
    public long InactiveEmailQuantity { get; set; }

    [JsonPropertyName("creationdate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("status")]
    public AddressBookStatus Status { get; set; }

    [JsonPropertyName("status_explain")]
    public string? StatusExplain { get; set; }
}
