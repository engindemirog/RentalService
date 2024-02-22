using FluentValidation;

namespace Application.Features.RentalBranches.Commands.Delete;

public class DeleteRentalBranchCommandValidator : AbstractValidator<DeleteRentalBranchCommand>
{
    public DeleteRentalBranchCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}