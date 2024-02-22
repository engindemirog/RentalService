using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RentalsAdditionalServices.Queries.GetList;

public class GetListRentalsAdditionalServiceQuery : IRequest<GetListResponse<GetListRentalsAdditionalServiceListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRentalsAdditionalServiceQueryHandler : IRequestHandler<GetListRentalsAdditionalServiceQuery, GetListResponse<GetListRentalsAdditionalServiceListItemDto>>
    {
        private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
        private readonly IMapper _mapper;

        public GetListRentalsAdditionalServiceQueryHandler(IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository, IMapper mapper)
        {
            _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRentalsAdditionalServiceListItemDto>> Handle(GetListRentalsAdditionalServiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RentalsAdditionalService> rentalsAdditionalServices = await _rentalsAdditionalServiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRentalsAdditionalServiceListItemDto> response = _mapper.Map<GetListResponse<GetListRentalsAdditionalServiceListItemDto>>(rentalsAdditionalServices);
            return response;
        }
    }
}