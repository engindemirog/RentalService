using Application.Features.RentalsAdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentalsAdditionalServices.Queries.GetById;

public class GetByIdRentalsAdditionalServiceQuery : IRequest<GetByIdRentalsAdditionalServiceResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRentalsAdditionalServiceQueryHandler : IRequestHandler<GetByIdRentalsAdditionalServiceQuery, GetByIdRentalsAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
        private readonly RentalsAdditionalServiceBusinessRules _rentalsAdditionalServiceBusinessRules;

        public GetByIdRentalsAdditionalServiceQueryHandler(IMapper mapper, IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository, RentalsAdditionalServiceBusinessRules rentalsAdditionalServiceBusinessRules)
        {
            _mapper = mapper;
            _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
            _rentalsAdditionalServiceBusinessRules = rentalsAdditionalServiceBusinessRules;
        }

        public async Task<GetByIdRentalsAdditionalServiceResponse> Handle(GetByIdRentalsAdditionalServiceQuery request, CancellationToken cancellationToken)
        {
            RentalsAdditionalService? rentalsAdditionalService = await _rentalsAdditionalServiceRepository.GetAsync(predicate: ras => ras.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalsAdditionalServiceBusinessRules.RentalsAdditionalServiceShouldExistWhenSelected(rentalsAdditionalService);

            GetByIdRentalsAdditionalServiceResponse response = _mapper.Map<GetByIdRentalsAdditionalServiceResponse>(rentalsAdditionalService);
            return response;
        }
    }
}