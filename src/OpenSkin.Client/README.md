# OpenSkin .NET SDK

.NET 8 client for the OpenSkin Platform API.

## Install

```sh
dotnet add package OpenSkin.Client --version 0.1.0
```

## Example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenSkin.Client;
using OpenSkin.Client.Api;

using var host = Host.CreateDefaultBuilder()
    .ConfigureOpenSkin(Environment.GetEnvironmentVariable("OPENSKIN_API_KEY")!)
    .Build();

var platform = host.Services.GetRequiredService<IPlatformV2Api>();
var response = await platform.GetV2HealthAsync();
Console.WriteLine(response.Ok()?.Status);
```

The client uses `https://api-v2.openskin.dev` by default. Create an API key in
the [OpenSkin dashboard](https://platform.openskin.dev/dashboard).

Requests and responses use generated .NET types. Required headers such as
`Idempotency-Key` and `If-Match` are method arguments.

Licensed under the MIT License.
