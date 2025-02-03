using Application.Features.Category.Rules;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Category.Queries.GetById;

public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public GetByIdCategoryQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            CategoryBusinessRules categoryBusinessRules
        )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryIdShouldExistWhenSelected(request.Id);

            Domain.Entities.Category? category = await _categoryRepository.GetAsync(predicate: b => b.Id == request.Id, include: b => b.Include(b => b.SubCategories));
            GetByIdCategoryResponse categoryDto = _mapper.Map<GetByIdCategoryResponse>(category);
            return categoryDto;
        }
    }
}