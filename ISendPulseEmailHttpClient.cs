using Stxima.SendPulseClient.Models.Request;
using Stxima.SendPulseClient.Models.Response;

namespace Stxima.SendPulseClient;

public interface ISendPulseEmailHttpClient
{
    Task<List<AddressBookResponse>> GetAddressBooksAsync(
        int offset = 0,
        int limit = 25,
        CancellationToken cancellationToken = default
    );

    Task<SendMailResponse> SendMailAsync(
        SendMailRequest request,
        CancellationToken cancellationToken = default
    );
}
