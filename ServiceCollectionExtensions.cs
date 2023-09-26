using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stxima.SendPulseClient.Configuration;

namespace Stxima.SendPulseClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSendPulseApiClient(
        this IServiceCollection services,
        IConfiguration configuration,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped
    )
    {
        services.Configure<SendPulseConfiguration>(configuration.GetSection("SendPulse").Bind);

        services.AddHttpClient<ISendPulseEmailHttpClient>();

        services.Add(
            ServiceDescriptor.Describe(
                serviceType: typeof(ISendPulseEmailHttpClient),
                provider => new SendPulseEmailHttpClient(
                    provider.GetRequiredService<IOptions<SendPulseConfiguration>>(),
                    provider.GetService<ILogger<SendPulseEmailHttpClient>>(),
                    provider.GetRequiredService<IMemoryCache>()
                ),
                lifetime: serviceLifetime)
        );

        return services;
    }
}