using Application.Features.AdditionalServices.Commands.Create;
using Application.Features.AdditionalServices.Commands.Delete;
using Application.Features.AdditionalServices.Commands.Update;
using Application.Features.AdditionalServices.Queries.GetById;
using Application.Features.AdditionalServices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdditionalServices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AdditionalService, CreateAdditionalServiceCommand>().ReverseMap();
        CreateMap<AdditionalService, CreatedAdditionalServiceResponse>().ReverseMap();
        CreateMap<AdditionalService, UpdateAdditionalServiceCommand>().ReverseMap();
        CreateMap<AdditionalService, UpdatedAdditionalServiceResponse>().ReverseMap();
        CreateMap<AdditionalService, DeleteAdditionalServiceCommand>().ReverseMap();
        CreateMap<AdditionalService, DeletedAdditionalServiceResponse>().ReverseMap();
        CreateMap<AdditionalService, GetByIdAdditionalServiceResponse>().ReverseMap();
        CreateMap<AdditionalService, GetListAdditionalServiceListItemDto>().ReverseMap();
        CreateMap<IPaginate<AdditionalService>, GetListResponse<GetListAdditionalServiceListItemDto>>().ReverseMap();
    }
}