using Application.Features.Product.Rules;
using Application.Pipelines.Authorization;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Features.Product.Constants.ProductOperationClaims;

namespace Application.Features.Product.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockCount { get; set; }
    public double? Price { get; set; }
    public long CategoryId { get; set; }

    public string[] Roles => new[] { Admin, Write, Add };

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product mappedProduct = _mapper.Map<Domain.Entities.Product>(request);
            Domain.Entities.Product createdProduct = await _productRepository.AddAsync(mappedProduct);
            CreatedProductResponse createdProductDto = _mapper.Map<CreatedProductResponse>(createdProduct);
            return createdProductDto;
        }
    }
}