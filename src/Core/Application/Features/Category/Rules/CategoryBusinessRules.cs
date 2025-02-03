using Application.Features.Category.Constants;
using Application.Rules;
using CrossCuttingConcerns.Exceptions.Types;
using Domain.Repositories;

namespace Application.Features.Category.Rules;

public class CategoryBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CategoryIdShouldExistWhenSelected(int id)
    {
        Domain.Entities.Category? result = await _categoryRepository.GetAsync(predicate: b => b.Id == id, enableTracking: false);
        if (result == null)
            throw new BusinessException(CategoryMessages.CategoryNotExists);
    }

    public async Task CategoryMustNotHaveSubCategories(int id)
    {
        bool result = await _categoryRepository.AnyAsync(predicate: b => b.ParentCategoryId == id, enableTracking: false);
        if (result)
            throw new BusinessException(CategoryMessages.CategoryHasSubs);
    }
}