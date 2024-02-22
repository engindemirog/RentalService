using FluentValidation;

namespace Application.Features.RentalsAdditionalServices.Commands.Create;

public class CreateRentalsAdditionalServiceCommandValidator : AbstractValidator<CreateRentalsAdditionalServiceCommand>
{
    public CreateRentalsAdditionalServiceCommandValidator()
    {
        RuleFor(c => c.RentalId).NotEmpty();
        RuleFor(c => c.AdditionalServiceId).NotEmpty();
    }
}