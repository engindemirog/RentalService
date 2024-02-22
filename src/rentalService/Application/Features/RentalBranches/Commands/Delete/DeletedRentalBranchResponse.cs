using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentalBranches.Commands.Delete;

public class DeletedRentalBranchResponse : IResponse
{
    public Guid Id { get; set; }
}