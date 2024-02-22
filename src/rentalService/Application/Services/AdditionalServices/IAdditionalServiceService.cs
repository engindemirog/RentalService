using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdditionalServices;

public interface IAdditionalServiceService
{
    Task<AdditionalService?> GetAsync(
        Expression<Func<AdditionalService, bool>> predicate,
        Func<IQueryable<AdditionalService>, IIncludableQueryable<AdditionalService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AdditionalService>?> GetListAsync(
        Expression<Func<AdditionalService, bool>>? predicate = null,
        Func<IQueryable<AdditionalService>, IOrderedQueryable<AdditionalService>>? orderBy = null,
        Func<IQueryable<AdditionalService>, IIncludableQueryable<AdditionalService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AdditionalService> AddAsync(AdditionalService additionalService);
    Task<AdditionalService> UpdateAsync(AdditionalService additionalService);
    Task<AdditionalService> DeleteAsync(AdditionalService additionalService, bool permanent = false);
}
