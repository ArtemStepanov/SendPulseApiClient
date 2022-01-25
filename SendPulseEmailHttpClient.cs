using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Stxima.SendPulseClient.Models.Request;
using Stxima.SendPulseClient.Models.Response;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Stxima.SendPulseClient;

public sealed class SendPulseEmailHttpClient : HttpClient, ISendPulseEmailHttpClient
{
    private readonly string _clientId;
    private readonly string _clientSecretToken;
    private readonly ILogger<SendPulseEmailHttpClient>? _logger;
    private readonly IMemoryCache _memoryCache;
    private const string BaseUrl = "https://api.sendpulse.com";

    public SendPulseEmailHttpClient(
        string clientId,
        string clientSecretToken,
        ILogger<SendPulseEmailHttpClient>? logger,
        IMemoryCache memoryCache
    )
    {
        BaseAddress = new Uri(BaseUrl);
        _clientId = clientId;
        _clientSecretToken = clientSecretToken;
        _logger = logger;
        _memoryCache = memoryCache;
    }

    public async Task<List<AddressBookResponse>> GetAddressBooksAsync(
        int offset = 0,
        int limit = 25,
        CancellationToken cancellationToken = default
    )
    {
        await AuthorizeAsync(cancellationToken);
        var response = await GetAsync(
            requestUri: $"addressbooks?offset={offset}&limit={limit}",
            cancellationToken: cancellationToken
        );

        await ValidateResponse(response);

        var parsed =
            await response.Content.ReadFromJsonAsync<List<AddressBookResponse>>(cancellationToken: cancellationToken);

        return parsed!;
    }

    public async Task<SendMailResponse> SendMailAsync(
        SendMailRequest request,
        CancellationToken cancellationToken = default
    )
    {
        await AuthorizeAsync(cancellationToken);

        var response = await PostAsync(
            requestUri: $"smtp/emails",
            content: JsonContent.Create(request),
            cancellationToken: cancellationToken
        );

        await ValidateResponse(response);

        var parsed =
            await response.Content.ReadFromJsonAsync<SendMailResponse>(cancellationToken: cancellationToken);

        return parsed!;
    }

    private async Task AuthorizeAsync(CancellationToken cancellationToken = default)
    {
        if (_memoryCache.TryGetValue(CacheKeys.OAuthTokenKey, out _))
            return;

        HttpResponseMessage response = await PostAsync(
            requestUri: "oauth/access_token",
            content: JsonContent.Create(new OAuthTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecretToken
            }), cancellationToken: cancellationToken);

        await ValidateResponse(response);

        OAuthTokenResponse parsedResponse =
            (await response.Content.ReadFromJsonAsync<OAuthTokenResponse>(cancellationToken: cancellationToken))!;

        _memoryCache.Set(
            key: CacheKeys.OAuthTokenKey,
            value: parsedResponse,
            absoluteExpirationRelativeToNow: TimeSpan.FromSeconds(parsedResponse.ExpiresIn)
        );

        DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            parsedResponse.TokenType!,
            parsedResponse.AccessToken
        );
    }

    private async Task ValidateResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Implement exception handling");
        }
    }
}
