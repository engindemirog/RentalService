using FluentValidation;

namespace Application.Features.AdditionalServices.Commands.Create;

public class CreateAdditionalServiceCommandValidator : AbstractValidator<CreateAdditionalServiceCommand>
{
    public CreateAdditionalServiceCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
    }
}