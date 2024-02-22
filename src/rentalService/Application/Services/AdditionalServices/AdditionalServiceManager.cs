using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdditionalServices;

public class AdditionalServiceManager : IAdditionalServiceService
{
    private readonly IAdditionalServiceRepository _additionalServiceRepository;
    private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

    public AdditionalServiceManager(IAdditionalServiceRepository additionalServiceRepository, AdditionalServiceBusinessRules additionalServiceBusinessRules)
    {
        _additionalServiceRepository = additionalServiceRepository;
        _additionalServiceBusinessRules = additionalServiceBusinessRules;
    }

    public async Task<AdditionalService?> GetAsync(
        Expression<Func<AdditionalService, bool>> predicate,
        Func<IQueryable<AdditionalService>, IIncludableQueryable<AdditionalService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AdditionalService? additionalService = await _additionalServiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return additionalService;
    }

    public async Task<IPaginate<AdditionalService>?> GetListAsync(
        Expression<Func<AdditionalService, bool>>? predicate = null,
        Func<IQueryable<AdditionalService>, IOrderedQueryable<AdditionalService>>? orderBy = null,
        Func<IQueryable<AdditionalService>, IIncludableQueryable<AdditionalService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AdditionalService> additionalServiceList = await _additionalServiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return additionalServiceList;
    }

    public async Task<AdditionalService> AddAsync(AdditionalService additionalService)
    {
        AdditionalService addedAdditionalService = await _additionalServiceRepository.AddAsync(additionalService);

        return addedAdditionalService;
    }

    public async Task<AdditionalService> UpdateAsync(AdditionalService additionalService)
    {
        AdditionalService updatedAdditionalService = await _additionalServiceRepository.UpdateAsync(additionalService);

        return updatedAdditionalService;
    }

    public async Task<AdditionalService> DeleteAsync(AdditionalService additionalService, bool permanent = false)
    {
        AdditionalService deletedAdditionalService = await _additionalServiceRepository.DeleteAsync(additionalService);

        return deletedAdditionalService;
    }
}
