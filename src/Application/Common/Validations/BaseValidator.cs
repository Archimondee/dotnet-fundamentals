using System.Linq.Expressions;
using FluentValidation;

namespace NetCa.Domain.Common.Validations;

public static class ValidationMessages
{
  // ===== Common =====
  public const string Required = "{0} is required";
  public const string NotNull = "{0} must not be null";
  public const string Invalid = "{0} is invalid";

  // ===== String =====
  public const string MaxLength = "{0} must not exceed {1} characters";
  public const string MinLength = "{0} must be at least {1} characters";
  public const string ExactLength = "{0} must be exactly {1} characters";

  // ===== Format =====
  public const string Email = "{0} must be a valid email address";
  public const string Phone = "{0} must be a valid phone number";

  // ===== Numeric =====
  public const string GreaterThan = "{0} must be greater than {1}";
  public const string LessThan = "{0} must be less than {1}";

  // ===== Business =====
  public const string AlreadyExists = "{0} already exists";
  public const string NotFound = "{0} not found";
}

public abstract class BaseValidator<T> : AbstractValidator<T>
{
  protected BaseValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;
  }

  protected void RequiredRule<TProperty>(
      Expression<Func<T, TProperty>> expression,
      string fieldName)
  {
    RuleFor(expression)
        .NotEmpty()
        .WithMessage(string.Format(
            ValidationMessages.Required, fieldName));
  }

  protected void MaxLengthRule(
      Expression<Func<T, string>> expression,
      int max,
      string fieldName)
  {
    RuleFor(expression)
        .MaximumLength(max)
        .WithMessage(string.Format(
            ValidationMessages.MaxLength, fieldName, max));
  }

  protected void MinLengthRule(
      Expression<Func<T, string>> expression,
      int min,
      string fieldName)
  {
    RuleFor(expression)
        .MinimumLength(min)
        .WithMessage(string.Format(
            ValidationMessages.MinLength, fieldName, min));
  }

  protected void EmailRule(
      Expression<Func<T, string>> expression,
      string fieldName)
  {
    RuleFor(expression)
        .EmailAddress()
        .WithMessage(string.Format(
            ValidationMessages.Email, fieldName));
  }
}
