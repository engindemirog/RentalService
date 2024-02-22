using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdditionalServices.Commands.Create;

public class CreateAdditionalServiceCommand : IRequest<CreatedAdditionalServiceResponse>
{
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }

    public class CreateAdditionalServiceCommandHandler : IRequestHandler<CreateAdditionalServiceCommand, CreatedAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

        public CreateAdditionalServiceCommandHandler(IMapper mapper, IAdditionalServiceRepository additionalServiceRepository,
                                         AdditionalServiceBusinessRules additionalServiceBusinessRules)
        {
            _mapper = mapper;
            _additionalServiceRepository = additionalServiceRepository;
            _additionalServiceBusinessRules = additionalServiceBusinessRules;
        }

        public async Task<CreatedAdditionalServiceResponse> Handle(CreateAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            AdditionalService additionalService = _mapper.Map<AdditionalService>(request);

            await _additionalServiceRepository.AddAsync(additionalService);

            CreatedAdditionalServiceResponse response = _mapper.Map<CreatedAdditionalServiceResponse>(additionalService);
            return response;
        }
    }
}