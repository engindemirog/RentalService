using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentalsAdditionalServices.Commands.Update;

public class UpdatedRentalsAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }
}