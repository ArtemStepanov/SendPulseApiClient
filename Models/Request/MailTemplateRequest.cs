using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Request;

public class MailTemplateRequest
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("variables")]
    public Dictionary<string, string> Variables { get; set; } = new();
}
