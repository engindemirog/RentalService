using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Contracts.Events.Features.Rentals;
using Domain.Entities;
using MassTransit;
using MediatR;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommand : IRequest<CreatedRentalResponse>
{
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid RentStartRentalBranchId { get; set; }
    public Guid? RentEndRentalBranchId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }

    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreatedRentalResponse>
    {


        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateRentalCommandHandler(IMapper mapper,
                                          IRentalRepository rentalRepository,
                                          RentalBusinessRules rentalBusinessRules,
                                          IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<CreatedRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            //await _rentalBusinessRules.PaymentShouldBeSuccessful(new PaymentRequest { Amount = 110 });

            Rental rental = _mapper.Map<Rental>(request);

            await _rentalRepository.AddAsync(rental);

            RentalCreatedEvent rentalCreatedEvent = new RentalCreatedEvent();
            rentalCreatedEvent.CarId = request.CarId;

            await _publishEndpoint.Publish(rentalCreatedEvent);

            CreatedRentalResponse response = _mapper.Map<CreatedRentalResponse>(rental);
            return response;
        }
    }
}