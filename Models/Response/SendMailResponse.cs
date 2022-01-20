using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Response;

public class SendMailResponse
{
    [JsonPropertyName("result")]
    public bool Result { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}
