using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace DotnetCA.Application.Common.Exceptions;

public class ValidationException : Exception
{
  public IDictionary<string, string[]> Errors { get; }

  public ValidationException(IEnumerable<ValidationFailure> failures)
      : base("Validation failed")
  {
    Errors = failures
        .GroupBy(x => x.PropertyName)
        .ToDictionary(
            g => g.Key,
            g => g.Select(x => x.ErrorMessage).ToArray()
        );
  }
}
