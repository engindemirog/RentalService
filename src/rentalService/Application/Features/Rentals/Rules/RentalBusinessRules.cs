using Application.Features.Rentals.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Rentals.Rules;

public class RentalBusinessRules : BaseBusinessRules
{
    private readonly IRentalRepository _rentalRepository;
    private readonly ILocalizationService _localizationService;

    public RentalBusinessRules(IRentalRepository rentalRepository, ILocalizationService localizationService)
    {
        _rentalRepository = rentalRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RentalsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RentalShouldExistWhenSelected(Rental? rental)
    {
        if (rental == null)
            await throwBusinessException(RentalsBusinessMessages.RentalNotExists);
    }

    public async Task RentalIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Rental? rental = await _rentalRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RentalShouldExistWhenSelected(rental);
    }
}