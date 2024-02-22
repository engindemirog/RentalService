using FluentValidation;

namespace Application.Features.RentalsAdditionalServices.Commands.Delete;

public class DeleteRentalsAdditionalServiceCommandValidator : AbstractValidator<DeleteRentalsAdditionalServiceCommand>
{
    public DeleteRentalsAdditionalServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}