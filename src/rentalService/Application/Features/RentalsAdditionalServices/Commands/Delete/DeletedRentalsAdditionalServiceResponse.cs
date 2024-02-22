using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentalsAdditionalServices.Commands.Delete;

public class DeletedRentalsAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
}