using Application.Features.RentalsAdditionalServices.Commands.Create;
using Application.Features.RentalsAdditionalServices.Commands.Delete;
using Application.Features.RentalsAdditionalServices.Commands.Update;
using Application.Features.RentalsAdditionalServices.Queries.GetById;
using Application.Features.RentalsAdditionalServices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsAdditionalServicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRentalsAdditionalServiceCommand createRentalsAdditionalServiceCommand)
    {
        CreatedRentalsAdditionalServiceResponse response = await Mediator.Send(createRentalsAdditionalServiceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRentalsAdditionalServiceCommand updateRentalsAdditionalServiceCommand)
    {
        UpdatedRentalsAdditionalServiceResponse response = await Mediator.Send(updateRentalsAdditionalServiceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRentalsAdditionalServiceResponse response = await Mediator.Send(new DeleteRentalsAdditionalServiceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRentalsAdditionalServiceResponse response = await Mediator.Send(new GetByIdRentalsAdditionalServiceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRentalsAdditionalServiceQuery getListRentalsAdditionalServiceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRentalsAdditionalServiceListItemDto> response = await Mediator.Send(getListRentalsAdditionalServiceQuery);
        return Ok(response);
    }
}