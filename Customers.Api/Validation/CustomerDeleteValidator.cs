using Customers.Api.Contracts.Requests;
using FluentValidation;
using Customers.Api.DBContext;

namespace Customers.Api.Validation
{
    public class CustomerDeleteValidator : AbstractValidator<CustomerDeleteRequest>
    {

        public CustomerDeleteValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            var context = new CustomerContext();
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Name should not be empty").MustAsync(async (name, cancellation) =>
            {
                var exists = await context.ExistsAsync(name, cancellation);
                return !exists;
            }).WithMessage("Customer does not exist");
        }
    }
}
