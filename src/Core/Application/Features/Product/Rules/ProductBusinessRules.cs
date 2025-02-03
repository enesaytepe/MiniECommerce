using Application.Features.Product.Constants;
using Application.Rules;
using CrossCuttingConcerns.Exceptions.Types;
using Domain.Repositories;

namespace Application.Features.Product.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ProductIdShouldExistWhenSelected(int id)
    {
        Domain.Entities.Product? result = await _productRepository.GetAsync(predicate: b => b.Id == id, enableTracking: false);
        if (result == null)
            throw new BusinessException(ProductMessages.ProductNotExists);
    }
}