using FluentValidation;

namespace Application.Features.Rentals.Commands.Delete;

public class DeleteRentalCommandValidator : AbstractValidator<DeleteRentalCommand>
{
    public DeleteRentalCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}