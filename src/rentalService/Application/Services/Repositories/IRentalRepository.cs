using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRentalRepository : IAsyncRepository<Rental, Guid>, IRepository<Rental, Guid>
{
}