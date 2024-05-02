namespace Customers.Api.Validation;

using System.Text.RegularExpressions;
using Contracts.Requests;
using FluentValidation;

public class CustomerRequestValidator : AbstractValidator<CustomerCreateRequest>
{
    private static readonly Regex FullNameRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public CustomerRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.FullName).NotEmpty().WithMessage("Name is empty").Matches(FullNameRegex).WithMessage("Name invalid");
        RuleFor(x => x.FullName).MustBeLettersAndHaveLength(3, 10);
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now)).NotEmpty().WithMessage("Date of birth should be in the past");
        RuleFor(x => x.WorkPlace).NotEmpty().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Workplace not provided");



        //RuleFor(x => x.FullName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name is empty").Matches(FullNameRegex).WithMessage("Name invalid");
    }
}

internal class ManualCustomerValidator
{
    private readonly Regex _fullNameRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private List<string> _errorMessages = new();

    public List<string> Validate(CustomerCreateRequest customer)
    {
        ValidateName(customer);
        // some other validations
        return _errorMessages;
    }
    public void ValidateAndThrow(CustomerCreateRequest customer)
    {
        var errors = Validate(customer);
        if (errors.Count > 0)
        {
            throw new ArgumentException(string.Join(',', errors));
        }
    }

    private void ValidateName(CustomerCreateRequest customer)
    {
        if (string.IsNullOrEmpty(customer.FullName))
        {
            _errorMessages.Add("Name is empty");
        }


        else if (_fullNameRegex.IsMatch(customer.FullName))
        {
            _errorMessages.Add("Name invalid");
        }
    }


}

