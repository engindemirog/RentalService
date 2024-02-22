using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdditionalServices.Commands.Update;

public class UpdateAdditionalServiceCommand : IRequest<UpdatedAdditionalServiceResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }

    public class UpdateAdditionalServiceCommandHandler : IRequestHandler<UpdateAdditionalServiceCommand, UpdatedAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

        public UpdateAdditionalServiceCommandHandler(IMapper mapper, IAdditionalServiceRepository additionalServiceRepository,
                                         AdditionalServiceBusinessRules additionalServiceBusinessRules)
        {
            _mapper = mapper;
            _additionalServiceRepository = additionalServiceRepository;
            _additionalServiceBusinessRules = additionalServiceBusinessRules;
        }

        public async Task<UpdatedAdditionalServiceResponse> Handle(UpdateAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            AdditionalService? additionalService = await _additionalServiceRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _additionalServiceBusinessRules.AdditionalServiceShouldExistWhenSelected(additionalService);
            additionalService = _mapper.Map(request, additionalService);

            await _additionalServiceRepository.UpdateAsync(additionalService!);

            UpdatedAdditionalServiceResponse response = _mapper.Map<UpdatedAdditionalServiceResponse>(additionalService);
            return response;
        }
    }
}