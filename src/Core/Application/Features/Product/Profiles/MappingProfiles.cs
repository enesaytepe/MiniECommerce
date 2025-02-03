using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Delete;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetById;
using Application.Features.Product.Queries.GetList;
using Application.Responses;
using AutoMapper;
using Domain.Paging;

namespace Application.Features.Product.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();
        CreateMap<Domain.Entities.Product, CreatedProductResponse>().ReverseMap();
        CreateMap<Domain.Entities.Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Domain.Entities.Product, UpdatedProductResponse>().ReverseMap();
        CreateMap<Domain.Entities.Product, DeleteProductCommand>().ReverseMap();
        CreateMap<Domain.Entities.Product, DeletedProductResponse>().ReverseMap();
        CreateMap<Domain.Entities.Product, GetByIdProductResponse>().ReverseMap();
        CreateMap<Domain.Entities.Product, GetAllListProductItemDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Product>, GetListResponse<GetAllListProductItemDto>>().ReverseMap();
    }
}