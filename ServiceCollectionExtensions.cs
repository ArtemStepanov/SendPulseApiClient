using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Stxima.SendPulseClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSendPulseApiClient(
        this IServiceCollection services,
        string clientId,
        string clientSecretToken,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped
    )
    {
        services.AddHttpClient<ISendPulseEmailHttpClient>();

        services.Add(
            ServiceDescriptor.Describe(
                serviceType: typeof(ISendPulseEmailHttpClient),
                provider => new SendPulseEmailHttpClient(
                    clientId,
                    clientSecretToken,
                    provider.GetService<ILogger<SendPulseEmailHttpClient>>(),
                    provider.GetRequiredService<IMemoryCache>()
                    ),
                lifetime: serviceLifetime)
        );

        return services;
    }
}
