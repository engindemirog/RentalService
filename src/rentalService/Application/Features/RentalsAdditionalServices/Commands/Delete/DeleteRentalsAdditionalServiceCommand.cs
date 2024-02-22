using Application.Features.RentalsAdditionalServices.Constants;
using Application.Features.RentalsAdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentalsAdditionalServices.Commands.Delete;

public class DeleteRentalsAdditionalServiceCommand : IRequest<DeletedRentalsAdditionalServiceResponse>
{
    public Guid Id { get; set; }

    public class DeleteRentalsAdditionalServiceCommandHandler : IRequestHandler<DeleteRentalsAdditionalServiceCommand, DeletedRentalsAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalsAdditionalServiceRepository _rentalsAdditionalServiceRepository;
        private readonly RentalsAdditionalServiceBusinessRules _rentalsAdditionalServiceBusinessRules;

        public DeleteRentalsAdditionalServiceCommandHandler(IMapper mapper, IRentalsAdditionalServiceRepository rentalsAdditionalServiceRepository,
                                         RentalsAdditionalServiceBusinessRules rentalsAdditionalServiceBusinessRules)
        {
            _mapper = mapper;
            _rentalsAdditionalServiceRepository = rentalsAdditionalServiceRepository;
            _rentalsAdditionalServiceBusinessRules = rentalsAdditionalServiceBusinessRules;
        }

        public async Task<DeletedRentalsAdditionalServiceResponse> Handle(DeleteRentalsAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            RentalsAdditionalService? rentalsAdditionalService = await _rentalsAdditionalServiceRepository.GetAsync(predicate: ras => ras.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalsAdditionalServiceBusinessRules.RentalsAdditionalServiceShouldExistWhenSelected(rentalsAdditionalService);

            await _rentalsAdditionalServiceRepository.DeleteAsync(rentalsAdditionalService!);

            DeletedRentalsAdditionalServiceResponse response = _mapper.Map<DeletedRentalsAdditionalServiceResponse>(rentalsAdditionalService);
            return response;
        }
    }
}