using Application.Features.Category.Constants;
using Application.Features.Category.Rules;
using Application.Pipelines.Authorization;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Features.Category.Constants.CategoryOperationClaims;

namespace Application.Features.Category.Commands.Delete;

public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryOperationClaims.Delete };

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            CategoryBusinessRules categoryBusinessRules,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _productRepository = productRepository;
        }

        public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryIdShouldExistWhenSelected(request.Id);
            await _categoryBusinessRules.CategoryMustNotHaveSubCategories(request.Id);

            List<Domain.Entities.Product>? products = await _productRepository.GetAllListAsync(predicate: p => p.CategoryId == request.Id);

            if (products?.Any() == true)
                await _productRepository.DeleteRangeAsync(products);

            Domain.Entities.Category mappedCategory = _mapper.Map<Domain.Entities.Category>(request);
            Domain.Entities.Category deletedCategory = await _categoryRepository.DeleteAsync(mappedCategory);
            DeletedCategoryResponse deletedCategoryDto = _mapper.Map<DeletedCategoryResponse>(deletedCategory);

            return deletedCategoryDto;
        }
    }
}