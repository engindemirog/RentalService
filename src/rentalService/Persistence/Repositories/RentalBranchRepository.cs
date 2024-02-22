using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RentalBranchRepository : EfRepositoryBase<RentalBranch, Guid, BaseDbContext>, IRentalBranchRepository
{
    public RentalBranchRepository(BaseDbContext context) : base(context)
    {
    }
}