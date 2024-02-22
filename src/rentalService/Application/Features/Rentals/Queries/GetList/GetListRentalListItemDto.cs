using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Rentals.Queries.GetList;

public class GetListRentalListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid RentStartRentalBranchId { get; set; }
    public Guid? RentEndRentalBranchId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }
}