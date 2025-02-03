using Application.Pipelines.Caching;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Paging;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Category.Queries.GetList;

public class GetListCategoryQuery : IRequest<GetListResponse<GetAllListCategoryItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => $"GetListCategories({PageRequest.Page},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCategories";

    public TimeSpan? SlidingExpiration { get; }

    public class GetListCategoryQueryHandler
        : IRequestHandler<GetListCategoryQuery, GetListResponse<GetAllListCategoryItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetAllListCategoryItemDto>> Handle(
            GetListCategoryQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Domain.Entities.Category> categories = await _categoryRepository.GetListAsync(
                 predicate: c => c.ParentCategoryId == null,
                 include: query => query.Include(c => c.SubCategories),
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
             );

            var mappedCategoryListModel = _mapper.Map<GetListResponse<GetAllListCategoryItemDto>>(categories);
            return mappedCategoryListModel;
        }
    }
}