using Application.Features.RentalBranches.Constants;
using Application.Features.RentalBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentalBranches.Commands.Delete;

public class DeleteRentalBranchCommand : IRequest<DeletedRentalBranchResponse>
{
    public Guid Id { get; set; }

    public class DeleteRentalBranchCommandHandler : IRequestHandler<DeleteRentalBranchCommand, DeletedRentalBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalBranchRepository _rentalBranchRepository;
        private readonly RentalBranchBusinessRules _rentalBranchBusinessRules;

        public DeleteRentalBranchCommandHandler(IMapper mapper, IRentalBranchRepository rentalBranchRepository,
                                         RentalBranchBusinessRules rentalBranchBusinessRules)
        {
            _mapper = mapper;
            _rentalBranchRepository = rentalBranchRepository;
            _rentalBranchBusinessRules = rentalBranchBusinessRules;
        }

        public async Task<DeletedRentalBranchResponse> Handle(DeleteRentalBranchCommand request, CancellationToken cancellationToken)
        {
            RentalBranch? rentalBranch = await _rentalBranchRepository.GetAsync(predicate: rb => rb.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBranchBusinessRules.RentalBranchShouldExistWhenSelected(rentalBranch);

            await _rentalBranchRepository.DeleteAsync(rentalBranch!);

            DeletedRentalBranchResponse response = _mapper.Map<DeletedRentalBranchResponse>(rentalBranch);
            return response;
        }
    }
}