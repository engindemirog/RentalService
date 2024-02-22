using Application.Features.RentalBranches.Commands.Create;
using Application.Features.RentalBranches.Commands.Delete;
using Application.Features.RentalBranches.Commands.Update;
using Application.Features.RentalBranches.Queries.GetById;
using Application.Features.RentalBranches.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalBranchesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRentalBranchCommand createRentalBranchCommand)
    {
        CreatedRentalBranchResponse response = await Mediator.Send(createRentalBranchCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRentalBranchCommand updateRentalBranchCommand)
    {
        UpdatedRentalBranchResponse response = await Mediator.Send(updateRentalBranchCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRentalBranchResponse response = await Mediator.Send(new DeleteRentalBranchCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRentalBranchResponse response = await Mediator.Send(new GetByIdRentalBranchQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRentalBranchQuery getListRentalBranchQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRentalBranchListItemDto> response = await Mediator.Send(getListRentalBranchQuery);
        return Ok(response);
    }
}