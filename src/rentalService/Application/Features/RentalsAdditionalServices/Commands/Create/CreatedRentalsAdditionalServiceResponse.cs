using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentalsAdditionalServices.Commands.Create;

public class CreatedRentalsAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }
}