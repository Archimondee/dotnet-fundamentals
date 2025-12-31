using DotnetCA.Api.Extensions;
using DotnetCA.Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

ThreadPool.SetMinThreads(
    workerThreads: Environment.ProcessorCount * 2,
    completionPortThreads: Environment.ProcessorCount * 2);

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

var appSetting = builder.Configuration.Get<AppSettings>()
    ?? throw new InvalidOperationException("AppSetting configuration is missing");

builder.Services.AddCorsPolicy(appSetting);
builder.ConfigureKestrelServer(appSetting);
builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(365);
    options.IncludeSubDomains = true;
    options.Preload = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseHttpsRedirection();
    app.UseCors(CorsExtensions.RestrictedCorsPolicy);
}

if (appSetting.Environment == "Development")
{
    app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
}

app.Run();
