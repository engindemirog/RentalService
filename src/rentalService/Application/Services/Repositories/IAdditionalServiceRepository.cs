using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdditionalServiceRepository : IAsyncRepository<AdditionalService, Guid>, IRepository<AdditionalService, Guid>
{
}