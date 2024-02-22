using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.RentalBranches.Commands.Create;

public class CreatedRentalBranchResponse : IResponse
{
    public Guid Id { get; set; }
    public City City { get; set; }
}