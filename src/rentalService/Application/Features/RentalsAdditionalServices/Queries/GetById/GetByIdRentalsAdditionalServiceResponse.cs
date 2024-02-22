using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentalsAdditionalServices.Queries.GetById;

public class GetByIdRentalsAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }
}