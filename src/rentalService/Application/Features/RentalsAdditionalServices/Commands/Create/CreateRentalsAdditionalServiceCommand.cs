using Application.Features.RentalsAdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentalsAdditionalServices.Commands.Create;

public class CreateRentalsAdditionalServiceCommand : IRequest<CreatedRentalsAdditionalServiceResponse>
{
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }

    public class CreateRentalsAdditionalServiceCommandHandler : IRequestHandler<CreateRentalsAdditionalServiceCommand, CreatedRentalsAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
        private readonly RentalsAdditionalServiceBusinessRules _rentalsAdditionalServiceBusinessRules;

        public CreateRentalsAdditionalServiceCommandHandler(IMapper mapper, IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository,
                                         RentalsAdditionalServiceBusinessRules rentalsAdditionalServiceBusinessRules)
        {
            _mapper = mapper;
            _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
            _rentalsAdditionalServiceBusinessRules = rentalsAdditionalServiceBusinessRules;
        }

        public async Task<CreatedRentalsAdditionalServiceResponse> Handle(CreateRentalsAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            RentalsAdditionalService rentalsAdditionalService = _mapper.Map<RentalsAdditionalService>(request);

            await _rentalsAdditionalServiceRepository.AddAsync(rentalsAdditionalService);

            CreatedRentalsAdditionalServiceResponse response = _mapper.Map<CreatedRentalsAdditionalServiceResponse>(rentalsAdditionalService);
            return response;
        }
    }
}