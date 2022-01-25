using System.Text;
using System.Text.Json.Serialization;

namespace Stxima.SendPulseClient.Models.Request;

public class SendMailRequest
{
    private string? _html;

    [JsonPropertyName("html")]
    public string? Html
    {
        get => !string.IsNullOrEmpty(_html) ? Convert.ToBase64String(Encoding.UTF8.GetBytes(_html)) : null;
        set => _html = value;
    }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("template")]
    public MailTemplateRequest? Template { get; set; }

    [JsonPropertyName("auto_plain_text")]
    public bool AutoPlainText { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("from")]
    public SendMailUserData? From { get; set; }

    [JsonPropertyName("to")]
    public List<SendMailUserData> To { get; set; } = new();
}
