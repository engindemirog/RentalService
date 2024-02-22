using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rentals.Commands.Delete;

public class DeletedRentalResponse : IResponse
{
    public Guid Id { get; set; }
}