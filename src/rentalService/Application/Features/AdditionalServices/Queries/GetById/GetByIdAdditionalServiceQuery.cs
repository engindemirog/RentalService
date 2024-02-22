using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdditionalServices.Queries.GetById;

public class GetByIdAdditionalServiceQuery : IRequest<GetByIdAdditionalServiceResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdditionalServiceQueryHandler : IRequestHandler<GetByIdAdditionalServiceQuery, GetByIdAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

        public GetByIdAdditionalServiceQueryHandler(IMapper mapper, IAdditionalServiceRepository additionalServiceRepository, AdditionalServiceBusinessRules additionalServiceBusinessRules)
        {
            _mapper = mapper;
            _additionalServiceRepository = additionalServiceRepository;
            _additionalServiceBusinessRules = additionalServiceBusinessRules;
        }

        public async Task<GetByIdAdditionalServiceResponse> Handle(GetByIdAdditionalServiceQuery request, CancellationToken cancellationToken)
        {
            AdditionalService? additionalService = await _additionalServiceRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _additionalServiceBusinessRules.AdditionalServiceShouldExistWhenSelected(additionalService);

            GetByIdAdditionalServiceResponse response = _mapper.Map<GetByIdAdditionalServiceResponse>(additionalService);
            return response;
        }
    }
}