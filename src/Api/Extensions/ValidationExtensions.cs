using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DotnetCA.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DotnetCA.Api.Extensions;

public class ValidationMiddleware
{
  private readonly RequestDelegate _next;

  public ValidationMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (ValidationException ex)
    {
      context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
      context.Response.ContentType = "application/json";

      var result = JsonSerializer.Serialize(new
      {
        message = "Validation failed",
        errors = ex.Errors
      });

      await context.Response.WriteAsync(result);
    }
  }
}
