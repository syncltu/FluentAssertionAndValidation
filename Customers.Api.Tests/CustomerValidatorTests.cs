using Customers.Api.Contracts.Requests;
using Customers.Api.Validation;
using FluentValidation.TestHelper;

namespace Customers.Api.Tests
{
    public class CustomerValidatorTests
    {
        private readonly CustomerRequestValidator _validator = new();

        public CustomerValidatorTests()
        {

        }

        [Fact]
        public void ShouldHaveValidationError_WhenFirstNameIsNotSpecified()
        {
            // Arrange
            var customerCreateRequest = new CustomerCreateRequest();

            // Act
            var result = _validator.TestValidate(customerCreateRequest);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.FullName).WithErrorMessage("Name is empty");
        }

        [Fact]
        public void ShouldNotHaveValidationError_WhenFirstNameIsSpecified()
        {
            // Arrange
            var customerCreateRequest = new CustomerCreateRequest()
            {
                FullName = "Martin"
            };

            // Act
            var result = _validator.TestValidate(customerCreateRequest);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.FullName);
            result.ShouldHaveAnyValidationError();
        }
    }
}