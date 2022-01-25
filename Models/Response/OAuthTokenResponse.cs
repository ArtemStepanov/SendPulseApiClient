using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Response;

public class OAuthTokenResponse
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }
}
