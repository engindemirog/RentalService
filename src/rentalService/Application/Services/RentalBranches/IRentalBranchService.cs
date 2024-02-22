using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RentalBranches;

public interface IRentalBranchService
{
    Task<RentalBranch?> GetAsync(
        Expression<Func<RentalBranch, bool>> predicate,
        Func<IQueryable<RentalBranch>, IIncludableQueryable<RentalBranch, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RentalBranch>?> GetListAsync(
        Expression<Func<RentalBranch, bool>>? predicate = null,
        Func<IQueryable<RentalBranch>, IOrderedQueryable<RentalBranch>>? orderBy = null,
        Func<IQueryable<RentalBranch>, IIncludableQueryable<RentalBranch, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RentalBranch> AddAsync(RentalBranch rentalBranch);
    Task<RentalBranch> UpdateAsync(RentalBranch rentalBranch);
    Task<RentalBranch> DeleteAsync(RentalBranch rentalBranch, bool permanent = false);
}
