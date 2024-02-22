using FluentValidation;

namespace Application.Features.RentalsAdditionalServices.Commands.Update;

public class UpdateRentalsAdditionalServiceCommandValidator : AbstractValidator<UpdateRentalsAdditionalServiceCommand>
{
    public UpdateRentalsAdditionalServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RentalId).NotEmpty();
        RuleFor(c => c.AdditionalServiceId).NotEmpty();
    }
}