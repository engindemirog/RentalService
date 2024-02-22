using Application.Features.RentalBranches.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RentalBranches;

public class RentalBranchManager : IRentalBranchService
{
    private readonly IRentalBranchRepository _rentalBranchRepository;
    private readonly RentalBranchBusinessRules _rentalBranchBusinessRules;

    public RentalBranchManager(IRentalBranchRepository rentalBranchRepository, RentalBranchBusinessRules rentalBranchBusinessRules)
    {
        _rentalBranchRepository = rentalBranchRepository;
        _rentalBranchBusinessRules = rentalBranchBusinessRules;
    }

    public async Task<RentalBranch?> GetAsync(
        Expression<Func<RentalBranch, bool>> predicate,
        Func<IQueryable<RentalBranch>, IIncludableQueryable<RentalBranch, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RentalBranch? rentalBranch = await _rentalBranchRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rentalBranch;
    }

    public async Task<IPaginate<RentalBranch>?> GetListAsync(
        Expression<Func<RentalBranch, bool>>? predicate = null,
        Func<IQueryable<RentalBranch>, IOrderedQueryable<RentalBranch>>? orderBy = null,
        Func<IQueryable<RentalBranch>, IIncludableQueryable<RentalBranch, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RentalBranch> rentalBranchList = await _rentalBranchRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return rentalBranchList;
    }

    public async Task<RentalBranch> AddAsync(RentalBranch rentalBranch)
    {
        RentalBranch addedRentalBranch = await _rentalBranchRepository.AddAsync(rentalBranch);

        return addedRentalBranch;
    }

    public async Task<RentalBranch> UpdateAsync(RentalBranch rentalBranch)
    {
        RentalBranch updatedRentalBranch = await _rentalBranchRepository.UpdateAsync(rentalBranch);

        return updatedRentalBranch;
    }

    public async Task<RentalBranch> DeleteAsync(RentalBranch rentalBranch, bool permanent = false)
    {
        RentalBranch deletedRentalBranch = await _rentalBranchRepository.DeleteAsync(rentalBranch);

        return deletedRentalBranch;
    }
}
