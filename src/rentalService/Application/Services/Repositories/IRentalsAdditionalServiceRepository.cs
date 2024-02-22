using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRentalsAdditionalServiceRepository : IAsyncRepository<RentalsAdditionalService, Guid>, IRepository<RentalsAdditionalService, Guid>
{
}