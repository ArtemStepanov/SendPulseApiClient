using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Request;

public class OAuthTokenRequest
{
    [JsonPropertyName("grant_type")]
    public static string GrantType => "client_credentials";

    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }
}
