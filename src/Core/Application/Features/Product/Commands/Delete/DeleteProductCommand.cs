using Application.Features.Product.Constants;
using Application.Features.Product.Rules;
using Application.Pipelines.Authorization;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Features.Product.Constants.ProductOperationClaims;

namespace Application.Features.Product.Commands.Delete;

public class DeleteProductCommand : IRequest<DeletedProductResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductOperationClaims.Delete };

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product mappedProduct = _mapper.Map<Domain.Entities.Product>(request);
            Domain.Entities.Product deletedProduct = await _productRepository.DeleteAsync(mappedProduct);
            DeletedProductResponse deletedProductDto = _mapper.Map<DeletedProductResponse>(deletedProduct);

            return deletedProductDto;
        }
    }
}