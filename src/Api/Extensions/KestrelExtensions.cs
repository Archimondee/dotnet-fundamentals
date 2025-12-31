
using DotnetCA.Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace DotnetCA.Api.Extensions;

public static class KestrelExtensions
{
  public static Microsoft.AspNetCore.Builder.WebApplicationBuilder ConfigureKestrelServer(this WebApplicationBuilder builder, AppSettings appSettings)
  {
    builder.WebHost.ConfigureKestrel((ctx, options) =>
        {
          options.AddServerHeader = false; // 🔐 security

          // ===== Connection limits =====
          options.Limits.MaxConcurrentConnections = 1000;
          options.Limits.MaxConcurrentUpgradedConnections = 100;

          // ===== Request limits =====
          options.Limits.MaxRequestBodySize =
              appSettings.Kestrel.Limits.MaxRequestBodySize;

          options.Limits.RequestHeadersTimeout =
              TimeSpan.FromSeconds(appSettings.Kestrel.Limits.RequestHeadersTimeoutSeconds);

          options.Limits.KeepAliveTimeout =
              TimeSpan.FromSeconds(appSettings.Kestrel.Limits.KeepAliveTimeoutSeconds);

          // ===== Timeouts =====
          options.Limits.MinRequestBodyDataRate =
              new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));

          options.Limits.MinResponseDataRate =
              new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
        });

    return builder;
  }
}
