using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RentalsAdditionalServices.Queries.GetList;

public class GetListRentalsAdditionalServiceListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }
}