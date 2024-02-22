using Application.Features.RentalsAdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentalsAdditionalServices.Commands.Update;

public class UpdateRentalsAdditionalServiceCommand : IRequest<UpdatedRentalsAdditionalServiceResponse>
{
    public Guid Id { get; set; }
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }

    public class UpdateRentalsAdditionalServiceCommandHandler : IRequestHandler<UpdateRentalsAdditionalServiceCommand, UpdatedRentalsAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
        private readonly RentalsAdditionalServiceBusinessRules _rentalsAdditionalServiceBusinessRules;

        public UpdateRentalsAdditionalServiceCommandHandler(IMapper mapper, IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository,
                                         RentalsAdditionalServiceBusinessRules rentalsAdditionalServiceBusinessRules)
        {
            _mapper = mapper;
            _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
            _rentalsAdditionalServiceBusinessRules = rentalsAdditionalServiceBusinessRules;
        }

        public async Task<UpdatedRentalsAdditionalServiceResponse> Handle(UpdateRentalsAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            RentalsAdditionalService? rentalsAdditionalService = await _rentalsAdditionalServiceRepository.GetAsync(predicate: ras => ras.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalsAdditionalServiceBusinessRules.RentalsAdditionalServiceShouldExistWhenSelected(rentalsAdditionalService);
            rentalsAdditionalService = _mapper.Map(request, rentalsAdditionalService);

            await _rentalsAdditionalServiceRepository.UpdateAsync(rentalsAdditionalService!);

            UpdatedRentalsAdditionalServiceResponse response = _mapper.Map<UpdatedRentalsAdditionalServiceResponse>(rentalsAdditionalService);
            return response;
        }
    }
}