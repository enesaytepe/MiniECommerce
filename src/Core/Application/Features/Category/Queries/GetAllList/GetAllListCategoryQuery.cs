using Application.Features.Category.Queries.GetList;
using Application.Pipelines.Caching;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Category.Queries.GetAllList;

public class GetAllListCategoryQuery : IRequest<List<GetAllListCategoryItemDto>>, ICachableRequest
{
    public bool BypassCache { get; }

    public string CacheKey => $"GetAllListCategories";
    public string CacheGroupKey => "GetAllCategories";

    public TimeSpan? SlidingExpiration { get; }

    public class GetAllListCategoryQueryHandler
        : IRequestHandler<GetAllListCategoryQuery, List<GetAllListCategoryItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllListCategoryItemDto>> Handle(
            GetAllListCategoryQuery request,
            CancellationToken cancellationToken
        )
        {
            List<Domain.Entities.Category> allCategories = await _categoryRepository.GetAllListAsync(cancellationToken: cancellationToken);

            // Kategorileri hiyerarşik yapıya dönüştürür.
            List<Domain.Entities.Category> hierarchicalCategories = BuildCategoryTree(allCategories);

            // Mapping yapılırken, MappingProfiles'da tanımlı recursive eşleme devreye girer.
            var mappedCategoryListModel = _mapper.Map<List<GetAllListCategoryItemDto>>(hierarchicalCategories);
            return mappedCategoryListModel;
        }

        private List<Domain.Entities.Category> BuildCategoryTree(List<Domain.Entities.Category> categories, long? parentId = null)
        {
            return categories
                .Where(c => c.ParentCategoryId == parentId)
                .Select(c =>
                {
                    c.SubCategories = BuildCategoryTree(categories, c.Id);
                    return c;
                })
                .ToList();
        }
    }
}