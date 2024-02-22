using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRentalBranchRepository : IAsyncRepository<RentalBranch, Guid>, IRepository<RentalBranch, Guid>
{
}