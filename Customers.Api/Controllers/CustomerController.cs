using System.Runtime.CompilerServices;
using Customers.Api.Validation;

namespace Customers.Api.Controllers;

using Contracts.Requests;
using Mapping;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IValidator<CustomerCreateRequest> _createValidator;
    private readonly IValidator<CustomerDeleteRequest> _deleteValidator;

    public CustomerController(IValidator<CustomerCreateRequest> createValidator, IValidator<CustomerDeleteRequest> deleteValidator)
    {
        _createValidator = createValidator;
        _deleteValidator = deleteValidator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CustomerCreateRequest createRequest)
    {
        var validationResult = await _createValidator.ValidateAsync(createRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var customer = createRequest.ToCustomer();

        //Some processing with adding to database goes there


        var customerResponse = customer.ToCustomerResponse();

        return Ok(customerResponse);
    }

    [HttpPost("create-v2")]
    public async Task<IActionResult> CreateV2([FromBody] CustomerCreateRequest createRequest)
    {
        await _createValidator.ValidateAndThrowAsync(createRequest);

        var customer = createRequest.ToCustomer();

        //Some processing with adding to database goes there


        var customerResponse = customer.ToCustomerResponse();

        return Ok(customerResponse);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] CustomerDeleteRequest deleteRequest)
    {
        var validationResult = await _deleteValidator.ValidateAsync(deleteRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        //Some processing with removing from database goes there

        return Ok();
    }
}
