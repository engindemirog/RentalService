using Application.Features.RentalBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.RentalBranches.Commands.Update;

public class UpdateRentalBranchCommand : IRequest<UpdatedRentalBranchResponse>
{
    public Guid Id { get; set; }
    public City City { get; set; }

    public class UpdateRentalBranchCommandHandler : IRequestHandler<UpdateRentalBranchCommand, UpdatedRentalBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalBranchRepository _rentalBranchRepository;
        private readonly RentalBranchBusinessRules _rentalBranchBusinessRules;

        public UpdateRentalBranchCommandHandler(IMapper mapper, IRentalBranchRepository rentalBranchRepository,
                                         RentalBranchBusinessRules rentalBranchBusinessRules)
        {
            _mapper = mapper;
            _rentalBranchRepository = rentalBranchRepository;
            _rentalBranchBusinessRules = rentalBranchBusinessRules;
        }

        public async Task<UpdatedRentalBranchResponse> Handle(UpdateRentalBranchCommand request, CancellationToken cancellationToken)
        {
            RentalBranch? rentalBranch = await _rentalBranchRepository.GetAsync(predicate: rb => rb.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBranchBusinessRules.RentalBranchShouldExistWhenSelected(rentalBranch);
            rentalBranch = _mapper.Map(request, rentalBranch);

            await _rentalBranchRepository.UpdateAsync(rentalBranch!);

            UpdatedRentalBranchResponse response = _mapper.Map<UpdatedRentalBranchResponse>(rentalBranch);
            return response;
        }
    }
}