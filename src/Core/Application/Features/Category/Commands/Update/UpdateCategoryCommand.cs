using Application.Features.Category.Constants;
using Application.Features.Category.Rules;
using Application.Pipelines.Authorization;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Features.Category.Constants.CategoryOperationClaims;

namespace Application.Features.Category.Commands.Update;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>, ISecuredRequest
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryOperationClaims.Update };

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public UpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            CategoryBusinessRules categoryBusinessRules
        )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            Domain.Entities.Category mappedCategory = _mapper.Map<UpdateCategoryCommand, Domain.Entities.Category>(request, category);
            Domain.Entities.Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
            UpdatedCategoryResponse updatedCategoryDto = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
            return updatedCategoryDto;
        }
    }
}
