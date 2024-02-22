using Application.Features.RentalBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentalBranches.Queries.GetById;

public class GetByIdRentalBranchQuery : IRequest<GetByIdRentalBranchResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRentalBranchQueryHandler : IRequestHandler<GetByIdRentalBranchQuery, GetByIdRentalBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalBranchRepository _rentalBranchRepository;
        private readonly RentalBranchBusinessRules _rentalBranchBusinessRules;

        public GetByIdRentalBranchQueryHandler(IMapper mapper, IRentalBranchRepository rentalBranchRepository, RentalBranchBusinessRules rentalBranchBusinessRules)
        {
            _mapper = mapper;
            _rentalBranchRepository = rentalBranchRepository;
            _rentalBranchBusinessRules = rentalBranchBusinessRules;
        }

        public async Task<GetByIdRentalBranchResponse> Handle(GetByIdRentalBranchQuery request, CancellationToken cancellationToken)
        {
            RentalBranch? rentalBranch = await _rentalBranchRepository.GetAsync(predicate: rb => rb.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBranchBusinessRules.RentalBranchShouldExistWhenSelected(rentalBranch);

            GetByIdRentalBranchResponse response = _mapper.Map<GetByIdRentalBranchResponse>(rentalBranch);
            return response;
        }
    }
}