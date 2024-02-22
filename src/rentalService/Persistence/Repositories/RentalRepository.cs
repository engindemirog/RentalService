using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RentalRepository : EfRepositoryBase<Rental, Guid, BaseDbContext>, IRentalRepository
{
    public RentalRepository(BaseDbContext context) : base(context)
    {
    }
}