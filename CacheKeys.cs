namespace Stxima.SendPulseClient;

internal static class CacheKeys
{
    private static readonly string CachePrefix = Guid.NewGuid().ToString("N");
    public static readonly string OAuthTokenKey = $"{CachePrefix}_Token";
}
