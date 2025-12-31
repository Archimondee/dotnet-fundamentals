namespace DotnetCA.Application.Common.Models;

public record AppSettings
{
  public string Environment { get; set; } = "";

  public Kestrel Kestrel { get; set; } = new();

  public Cors Cors { get; set; } = new();
}

public record Kestrel
{
  public string SectionName { get; set; } = "";

  public Limits Limits { get; set; } = new();
}

public record Limits
{
  public int MaxRequestBodySize { get; set; }

  public int RequestHeadersTimeoutSeconds { get; set; }

  public int KeepAliveTimeoutSeconds { get; set; }
}

public record Cors
{
  public string[] AllowedOrigins { get; set; }
}