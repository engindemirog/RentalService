using Application.Features.RentalBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.RentalBranches.Commands.Create;

public class CreateRentalBranchCommand : IRequest<CreatedRentalBranchResponse>
{
    public City City { get; set; }

    public class CreateRentalBranchCommandHandler : IRequestHandler<CreateRentalBranchCommand, CreatedRentalBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalBranchRepository _rentalBranchRepository;
        private readonly RentalBranchBusinessRules _rentalBranchBusinessRules;

        public CreateRentalBranchCommandHandler(IMapper mapper, IRentalBranchRepository rentalBranchRepository,
                                         RentalBranchBusinessRules rentalBranchBusinessRules)
        {
            _mapper = mapper;
            _rentalBranchRepository = rentalBranchRepository;
            _rentalBranchBusinessRules = rentalBranchBusinessRules;
        }

        public async Task<CreatedRentalBranchResponse> Handle(CreateRentalBranchCommand request, CancellationToken cancellationToken)
        {
            RentalBranch rentalBranch = _mapper.Map<RentalBranch>(request);

            await _rentalBranchRepository.AddAsync(rentalBranch);

            CreatedRentalBranchResponse response = _mapper.Map<CreatedRentalBranchResponse>(rentalBranch);
            return response;
        }
    }
}