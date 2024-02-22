using Application.Features.RentalBranches.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RentalBranches.Rules;

public class RentalBranchBusinessRules : BaseBusinessRules
{
    private readonly IRentalBranchRepository _rentalBranchRepository;
    private readonly ILocalizationService _localizationService;

    public RentalBranchBusinessRules(IRentalBranchRepository rentalBranchRepository, ILocalizationService localizationService)
    {
        _rentalBranchRepository = rentalBranchRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RentalBranchesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RentalBranchShouldExistWhenSelected(RentalBranch? rentalBranch)
    {
        if (rentalBranch == null)
            await throwBusinessException(RentalBranchesBusinessMessages.RentalBranchNotExists);
    }

    public async Task RentalBranchIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RentalBranch? rentalBranch = await _rentalBranchRepository.GetAsync(
            predicate: rb => rb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RentalBranchShouldExistWhenSelected(rentalBranch);
    }
}