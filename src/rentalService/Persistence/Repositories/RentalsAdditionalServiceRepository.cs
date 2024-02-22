using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RentalsAdditionalServiceRepository : EfRepositoryBase<RentalsAdditionalService, Guid, BaseDbContext>, IRentalsAdditionalServiceRepository
{
    public RentalsAdditionalServiceRepository(BaseDbContext context) : base(context)
    {
    }
}