using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AdditionalServices.Queries.GetList;

public class GetListAdditionalServiceListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
}