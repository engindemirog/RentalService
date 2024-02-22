using FluentValidation;

namespace Application.Features.AdditionalServices.Commands.Update;

public class UpdateAdditionalServiceCommandValidator : AbstractValidator<UpdateAdditionalServiceCommand>
{
    public UpdateAdditionalServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
    }
}