using Application.Features.RentalsAdditionalServices.Commands.Create;
using Application.Features.RentalsAdditionalServices.Commands.Delete;
using Application.Features.RentalsAdditionalServices.Commands.Update;
using Application.Features.RentalsAdditionalServices.Queries.GetById;
using Application.Features.RentalsAdditionalServices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RentalsAdditionalServices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RentalsAdditionalService, CreateRentalsAdditionalServiceCommand>().ReverseMap();
        CreateMap<RentalsAdditionalService, CreatedRentalsAdditionalServiceResponse>().ReverseMap();
        CreateMap<RentalsAdditionalService, UpdateRentalsAdditionalServiceCommand>().ReverseMap();
        CreateMap<RentalsAdditionalService, UpdatedRentalsAdditionalServiceResponse>().ReverseMap();
        CreateMap<RentalsAdditionalService, DeleteRentalsAdditionalServiceCommand>().ReverseMap();
        CreateMap<RentalsAdditionalService, DeletedRentalsAdditionalServiceResponse>().ReverseMap();
        CreateMap<RentalsAdditionalService, GetByIdRentalsAdditionalServiceResponse>().ReverseMap();
        CreateMap<RentalsAdditionalService, GetListRentalsAdditionalServiceListItemDto>().ReverseMap();
        CreateMap<IPaginate<RentalsAdditionalService>, GetListResponse<GetListRentalsAdditionalServiceListItemDto>>().ReverseMap();
    }
}