using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdditionalServices.Commands.Create;

public class CreatedAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
}