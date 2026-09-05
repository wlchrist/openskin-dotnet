using System;
using Microsoft.Extensions.Hosting;
using OpenSkin.Client.Client;
using OpenSkin.Client.Extensions;

namespace OpenSkin.Client;

/// <summary>Convenience configuration for the OpenSkin Platform client.</summary>
public static class OpenSkinPlatform
{
    /// <summary>OpenSkin's production API host.</summary>
    public const string ProductionBaseUrl = "https://api-v2.openskin.dev";
    /// <summary>The OpenSkin v2-test API host.</summary>
    public const string V2TestBaseUrl = "https://api-v2-v2-test.up.railway.app";

    /// <summary>Adds every generated OpenSkin API service to the host.</summary>
    public static IHostBuilder ConfigureOpenSkin(
        this IHostBuilder builder,
        string apiKey,
        string baseUrl = ProductionBaseUrl)
    {
        return builder.ConfigureApi((_, options) =>
        {
            options.AddTokens(new ApiKeyToken(
                apiKey,
                ClientUtils.ApiKeyHeader.X_API_Key,
                prefix: string.Empty));
            options.UseProvider<RateLimitProvider<ApiKeyToken>, ApiKeyToken>();
            options.AddApiHttpClients(client => client.BaseAddress = new Uri(baseUrl));
        });
    }
}
