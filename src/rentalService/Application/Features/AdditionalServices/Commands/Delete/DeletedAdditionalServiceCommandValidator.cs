using FluentValidation;

namespace Application.Features.AdditionalServices.Commands.Delete;

public class DeleteAdditionalServiceCommandValidator : AbstractValidator<DeleteAdditionalServiceCommand>
{
    public DeleteAdditionalServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}