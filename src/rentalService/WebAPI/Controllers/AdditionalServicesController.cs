using Application.Features.AdditionalServices.Commands.Create;
using Application.Features.AdditionalServices.Commands.Delete;
using Application.Features.AdditionalServices.Commands.Update;
using Application.Features.AdditionalServices.Queries.GetById;
using Application.Features.AdditionalServices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdditionalServicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdditionalServiceCommand createAdditionalServiceCommand)
    {
        CreatedAdditionalServiceResponse response = await Mediator.Send(createAdditionalServiceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdditionalServiceCommand updateAdditionalServiceCommand)
    {
        UpdatedAdditionalServiceResponse response = await Mediator.Send(updateAdditionalServiceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAdditionalServiceResponse response = await Mediator.Send(new DeleteAdditionalServiceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdditionalServiceResponse response = await Mediator.Send(new GetByIdAdditionalServiceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdditionalServiceQuery getListAdditionalServiceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdditionalServiceListItemDto> response = await Mediator.Send(getListAdditionalServiceQuery);
        return Ok(response);
    }
}