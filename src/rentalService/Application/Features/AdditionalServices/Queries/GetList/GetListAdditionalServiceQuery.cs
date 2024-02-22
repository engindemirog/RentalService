using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AdditionalServices.Queries.GetList;

public class GetListAdditionalServiceQuery : IRequest<GetListResponse<GetListAdditionalServiceListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdditionalServiceQueryHandler : IRequestHandler<GetListAdditionalServiceQuery, GetListResponse<GetListAdditionalServiceListItemDto>>
    {
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly IMapper _mapper;

        public GetListAdditionalServiceQueryHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdditionalServiceListItemDto>> Handle(GetListAdditionalServiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdditionalService> additionalServices = await _additionalServiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdditionalServiceListItemDto> response = _mapper.Map<GetListResponse<GetListAdditionalServiceListItemDto>>(additionalServices);
            return response;
        }
    }
}