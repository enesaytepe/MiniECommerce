using Application.Features.Product.Rules;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Product.Queries.GetById;

public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
{
    public int Id { get; set; }

    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetByIdProductQueryHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            await _productBusinessRules.ProductIdShouldExistWhenSelected(request.Id);

            Domain.Entities.Product? product = await _productRepository.GetAsync(predicate: b => b.Id == request.Id);
            GetByIdProductResponse productDto = _mapper.Map<GetByIdProductResponse>(product);
            return productDto;
        }
    }
}