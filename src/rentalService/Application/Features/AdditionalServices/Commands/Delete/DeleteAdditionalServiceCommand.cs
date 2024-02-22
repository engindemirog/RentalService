using Application.Features.AdditionalServices.Constants;
using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdditionalServices.Commands.Delete;

public class DeleteAdditionalServiceCommand : IRequest<DeletedAdditionalServiceResponse>
{
    public Guid Id { get; set; }

    public class DeleteAdditionalServiceCommandHandler : IRequestHandler<DeleteAdditionalServiceCommand, DeletedAdditionalServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

        public DeleteAdditionalServiceCommandHandler(IMapper mapper, IAdditionalServiceRepository additionalServiceRepository,
                                         AdditionalServiceBusinessRules additionalServiceBusinessRules)
        {
            _mapper = mapper;
            _additionalServiceRepository = additionalServiceRepository;
            _additionalServiceBusinessRules = additionalServiceBusinessRules;
        }

        public async Task<DeletedAdditionalServiceResponse> Handle(DeleteAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            AdditionalService? additionalService = await _additionalServiceRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _additionalServiceBusinessRules.AdditionalServiceShouldExistWhenSelected(additionalService);

            await _additionalServiceRepository.DeleteAsync(additionalService!);

            DeletedAdditionalServiceResponse response = _mapper.Map<DeletedAdditionalServiceResponse>(additionalService);
            return response;
        }
    }
}