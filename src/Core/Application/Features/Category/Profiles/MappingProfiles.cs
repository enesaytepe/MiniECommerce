using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Delete;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetById;
using Application.Features.Category.Queries.GetList;
using Application.Responses;
using AutoMapper;
using Domain.Paging;

namespace Application.Features.Category.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Category, CreatedCategoryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Category, UpdatedCategoryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Category, DeletedCategoryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Category, GetByIdCategoryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Category, GetAllListCategoryItemDto>()
         .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories))
         .ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Category>, GetListResponse<GetAllListCategoryItemDto>>().ReverseMap();
    }
}