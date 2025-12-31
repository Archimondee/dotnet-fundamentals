using DotnetCA.Application.Common.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCA.Api.Extensions;

public static class CorsExtensions
{
    public const string RestrictedCorsPolicy = "RestrictedCors";

    public static IServiceCollection AddCorsPolicy(
        this IServiceCollection services,
        AppSettings appSettings)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(RestrictedCorsPolicy, policy =>
            {
                policy
                    .WithOrigins(appSettings.Cors.AllowedOrigins)
                    .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
                    .WithHeaders("Content-Type", "Authorization")
                    .SetPreflightMaxAge(TimeSpan.FromMinutes(10));

                // ⚠️ Aktifkan hanya jika pakai cookie auth
                // policy.AllowCredentials();
            });
        });

        return services;
    }
}