using FluentValidation;

namespace Customers.Api.Validation
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> MustBeLettersAndHaveLength<T>(this IRuleBuilder<T, string> ruleBuilder, int minLength, int maxLength)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("The field is required.")
                .Length(minLength, maxLength).WithMessage($"The field must be between {minLength} and {maxLength} characters long.")
                .Matches("^[a-zA-Z]+$").WithMessage("The field can only contain letters.");
        }
    }
}
