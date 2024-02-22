using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RentalBranches.Queries.GetList;

public class GetListRentalBranchQuery : IRequest<GetListResponse<GetListRentalBranchListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRentalBranchQueryHandler : IRequestHandler<GetListRentalBranchQuery, GetListResponse<GetListRentalBranchListItemDto>>
    {
        private readonly IRentalBranchRepository _rentalBranchRepository;
        private readonly IMapper _mapper;

        public GetListRentalBranchQueryHandler(IRentalBranchRepository rentalBranchRepository, IMapper mapper)
        {
            _rentalBranchRepository = rentalBranchRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRentalBranchListItemDto>> Handle(GetListRentalBranchQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RentalBranch> rentalBranches = await _rentalBranchRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRentalBranchListItemDto> response = _mapper.Map<GetListResponse<GetListRentalBranchListItemDto>>(rentalBranches);
            return response;
        }
    }
}