using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rentals.Queries.GetById;

public class GetByIdRentalQuery : IRequest<GetByIdRentalResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRentalQueryHandler : IRequestHandler<GetByIdRentalQuery, GetByIdRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public GetByIdRentalQueryHandler(IMapper mapper, IRentalRepository rentalRepository, RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<GetByIdRentalResponse> Handle(GetByIdRentalQuery request, CancellationToken cancellationToken)
        {
            Rental? rental = await _rentalRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBusinessRules.RentalShouldExistWhenSelected(rental);

            GetByIdRentalResponse response = _mapper.Map<GetByIdRentalResponse>(rental);
            return response;
        }
    }
}