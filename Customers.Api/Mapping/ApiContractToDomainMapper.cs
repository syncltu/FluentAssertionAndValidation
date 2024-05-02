using Customers.Api.Contracts.Requests;
using Customers.Api.Domain;

namespace Customers.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CustomerCreateRequest createRequest)
    {
        return new Customer
        {
            Email = createRequest.Email,
            FullName = createRequest.FullName,
            DateOfBirth = createRequest.DateOfBirth
        };
    }

}
