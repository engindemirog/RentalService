using Application.Features.RentalsAdditionalServices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RentalsAdditionalServices;

public class RentalsAdditionalServiceManager : IRentalsAdditionalServiceService
{
    private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
    private readonly RentalsAdditionalServiceBusinessRules _rentalsAdditionalServiceBusinessRules;

    public RentalsAdditionalServiceManager(IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository, RentalsAdditionalServiceBusinessRules rentalsAdditionalServiceBusinessRules)
    {
        _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
        _rentalsAdditionalServiceBusinessRules = rentalsAdditionalServiceBusinessRules;
    }

    public async Task<RentalsAdditionalService?> GetAsync(
        Expression<Func<RentalsAdditionalService, bool>> predicate,
        Func<IQueryable<RentalsAdditionalService>, IIncludableQueryable<RentalsAdditionalService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RentalsAdditionalService? rentalsAdditionalService = await _rentalsAdditionalServiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rentalsAdditionalService;
    }

    public async Task<IPaginate<RentalsAdditionalService>?> GetListAsync(
        Expression<Func<RentalsAdditionalService, bool>>? predicate = null,
        Func<IQueryable<RentalsAdditionalService>, IOrderedQueryable<RentalsAdditionalService>>? orderBy = null,
        Func<IQueryable<RentalsAdditionalService>, IIncludableQueryable<RentalsAdditionalService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RentalsAdditionalService> rentalsAdditionalServiceList = await _rentalsAdditionalServiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return rentalsAdditionalServiceList;
    }

    public async Task<RentalsAdditionalService> AddAsync(RentalsAdditionalService rentalsAdditionalService)
    {
        RentalsAdditionalService addedRentalsAdditionalService = await _rentalsAdditionalServiceRepository.AddAsync(rentalsAdditionalService);

        return addedRentalsAdditionalService;
    }

    public async Task<RentalsAdditionalService> UpdateAsync(RentalsAdditionalService rentalsAdditionalService)
    {
        RentalsAdditionalService updatedRentalsAdditionalService = await _rentalsAdditionalServiceRepository.UpdateAsync(rentalsAdditionalService);

        return updatedRentalsAdditionalService;
    }

    public async Task<RentalsAdditionalService> DeleteAsync(RentalsAdditionalService rentalsAdditionalService, bool permanent = false)
    {
        RentalsAdditionalService deletedRentalsAdditionalService = await _rentalsAdditionalServiceRepository.DeleteAsync(rentalsAdditionalService);

        return deletedRentalsAdditionalService;
    }
}
