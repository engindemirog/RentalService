using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdditionalServices.Queries.GetById;

public class GetByIdAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
}