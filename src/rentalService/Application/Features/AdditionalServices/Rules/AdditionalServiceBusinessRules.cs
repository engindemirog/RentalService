using Application.Features.AdditionalServices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AdditionalServices.Rules;

public class AdditionalServiceBusinessRules : BaseBusinessRules
{
    private readonly IAdditionalServiceRepository _additionalServiceRepository;
    private readonly ILocalizationService _localizationService;

    public AdditionalServiceBusinessRules(IAdditionalServiceRepository additionalServiceRepository, ILocalizationService localizationService)
    {
        _additionalServiceRepository = additionalServiceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdditionalServicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdditionalServiceShouldExistWhenSelected(AdditionalService? additionalService)
    {
        if (additionalService == null)
            await throwBusinessException(AdditionalServicesBusinessMessages.AdditionalServiceNotExists);
    }

    public async Task AdditionalServiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AdditionalService? additionalService = await _additionalServiceRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdditionalServiceShouldExistWhenSelected(additionalService);
    }
}