using Application.Pipelines.Caching;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Paging;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Product.Queries.GetList;

public class GetListProductQuery : IRequest<GetListResponse<GetAllListProductItemDto>>, ICachableRequest
{
    public long? CategoryId { get; set; }
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => $"GetListProducts({PageRequest.Page},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProducts";

    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductQueryHandler
        : IRequestHandler<GetListProductQuery, GetListResponse<GetAllListProductItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetAllListProductItemDto>> Handle(
            GetListProductQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Domain.Entities.Product> products = await _productRepository.GetListAsync(
                 predicate: c => request.CategoryId == null || c.CategoryId == request.CategoryId,
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
             );

            var mappedProductListModel = _mapper.Map<GetListResponse<GetAllListProductItemDto>>(products);
            return mappedProductListModel;
        }
    }
}