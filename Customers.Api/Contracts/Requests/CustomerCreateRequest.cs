namespace Customers.Api.Contracts.Requests;

public class CustomerCreateRequest
{
    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateOnly DateOfBirth { get; init; } = default!;

    public string WorkPlace { get; init; } = default!;
}
