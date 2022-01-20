using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models;

public class SendMailUserData
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}
