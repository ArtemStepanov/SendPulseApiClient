using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Response;

public class UnsubscribedCustomer
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("unsubscribe_by_link")]
    public int UnsubscribeByLink { get; set; }

    [JsonPropertyName("unsubscribe_by_user")]
    public int UnsubscribeByUser { get; set; }

    [JsonPropertyName("spam_complaint")]
    public int SpamComplaint { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
}
