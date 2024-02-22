using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdditionalServiceRepository : EfRepositoryBase<AdditionalService, Guid, BaseDbContext>, IAdditionalServiceRepository
{
    public AdditionalServiceRepository(BaseDbContext context) : base(context)
    {
    }
}