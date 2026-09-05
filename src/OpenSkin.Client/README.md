# OpenSkin .NET SDK

.NET 8 client for the OpenSkin Platform API.

## Install

```sh
dotnet add package OpenSkin.Client --version 0.1.0
```

## Example

```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenSkin.Client;
using OpenSkin.Client.Api;

var apiKey = Environment.GetEnvironmentVariable("OPENSKIN_API_KEY");
if (string.IsNullOrWhiteSpace(apiKey))
    throw new InvalidOperationException("set OPENSKIN_API_KEY before running");

using var host = Host.CreateDefaultBuilder()
    .ConfigureOpenSkin(apiKey)
    .Build();

var platform = host.Services.GetRequiredService<IPlatformV2Api>();
var response = await platform.GetV2PrincipalAsync();
Console.WriteLine(response.Ok()?.Tier);
```

The client uses `https://api-v2.openskin.dev` by default. Create an API key in
the [OpenSkin dashboard](https://platform.openskin.dev/dashboard).

See the [API reference](https://platform.openskin.dev/docs/platform) for the
available operations. Requests and responses use generated .NET types.
Endpoints that require `Idempotency-Key` or `If-Match` expose those headers as
required method arguments.

Licensed under the MIT License.
