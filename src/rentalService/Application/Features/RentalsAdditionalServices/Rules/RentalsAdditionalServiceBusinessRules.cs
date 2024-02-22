using Application.Features.RentalsAdditionalServices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RentalsAdditionalServices.Rules;

public class RentalsAdditionalServiceBusinessRules : BaseBusinessRules
{
    private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
    private readonly ILocalizationService _localizationService;

    public RentalsAdditionalServiceBusinessRules(IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository, ILocalizationService localizationService)
    {
        _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RentalsAdditionalServicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RentalsAdditionalServiceShouldExistWhenSelected(RentalsAdditionalService? rentalsAdditionalService)
    {
        if (rentalsAdditionalService == null)
            await throwBusinessException(RentalsAdditionalServicesBusinessMessages.RentalsAdditionalServiceNotExists);
    }

    public async Task RentalsAdditionalServiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RentalsAdditionalService? rentalsAdditionalService = await _rentalsAdditionalServiceRepository.GetAsync(
            predicate: ras => ras.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RentalsAdditionalServiceShouldExistWhenSelected(rentalsAdditionalService);
    }
}