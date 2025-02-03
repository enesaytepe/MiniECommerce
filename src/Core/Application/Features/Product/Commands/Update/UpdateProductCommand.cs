using Application.Features.Product.Constants;
using Application.Features.Product.Rules;
using Application.Pipelines.Authorization;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Features.Product.Constants.ProductOperationClaims;

namespace Application.Features.Product.Commands.Update;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>, ISecuredRequest
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockCount { get; set; }
    public double? Price { get; set; }
    public long CategoryId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductOperationClaims.Update };

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _productRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            Domain.Entities.Product mappedProduct = _mapper.Map<UpdateProductCommand, Domain.Entities.Product>(request, product);
            Domain.Entities.Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
            UpdatedProductResponse updatedProductDto = _mapper.Map<UpdatedProductResponse>(updatedProduct);
            return updatedProductDto;
        }
    }
}
