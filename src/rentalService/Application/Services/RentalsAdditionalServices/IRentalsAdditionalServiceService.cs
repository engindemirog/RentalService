using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RentalsAdditionalServices;

public interface IRentalsAdditionalServiceService
{
    Task<RentalsAdditionalService?> GetAsync(
        Expression<Func<RentalsAdditionalService, bool>> predicate,
        Func<IQueryable<RentalsAdditionalService>, IIncludableQueryable<RentalsAdditionalService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RentalsAdditionalService>?> GetListAsync(
        Expression<Func<RentalsAdditionalService, bool>>? predicate = null,
        Func<IQueryable<RentalsAdditionalService>, IOrderedQueryable<RentalsAdditionalService>>? orderBy = null,
        Func<IQueryable<RentalsAdditionalService>, IIncludableQueryable<RentalsAdditionalService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RentalsAdditionalService> AddAsync(RentalsAdditionalService rentalsAdditionalService);
    Task<RentalsAdditionalService> UpdateAsync(RentalsAdditionalService rentalsAdditionalService);
    Task<RentalsAdditionalService> DeleteAsync(RentalsAdditionalService rentalsAdditionalService, bool permanent = false);
}
