using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rentals;

public interface IRentalService
{
    Task<Rental?> GetAsync(
        Expression<Func<Rental, bool>> predicate,
        Func<IQueryable<Rental>, IIncludableQueryable<Rental, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Rental>?> GetListAsync(
        Expression<Func<Rental, bool>>? predicate = null,
        Func<IQueryable<Rental>, IOrderedQueryable<Rental>>? orderBy = null,
        Func<IQueryable<Rental>, IIncludableQueryable<Rental, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Rental> AddAsync(Rental rental);
    Task<Rental> UpdateAsync(Rental rental);
    Task<Rental> DeleteAsync(Rental rental, bool permanent = false);
}
