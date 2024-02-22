using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdditionalServices.Commands.Delete;

public class DeletedAdditionalServiceResponse : IResponse
{
    public Guid Id { get; set; }
}