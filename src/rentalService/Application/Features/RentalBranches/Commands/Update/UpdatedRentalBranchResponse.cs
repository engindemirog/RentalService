using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.RentalBranches.Commands.Update;

public class UpdatedRentalBranchResponse : IResponse
{
    public Guid Id { get; set; }
    public City City { get; set; }
}