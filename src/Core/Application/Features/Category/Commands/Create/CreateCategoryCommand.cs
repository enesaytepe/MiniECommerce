using Application.Features.Category.Rules;
using Application.Pipelines.Authorization;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Features.Category.Constants.CategoryOperationClaims;

namespace Application.Features.Category.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }

    public string[] Roles => new[] { Admin, Write, Add };

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            CategoryBusinessRules categoryBusinessRules
        )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category mappedCategory = _mapper.Map<Domain.Entities.Category>(request);
            Domain.Entities.Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreatedCategoryResponse createdCategoryDto = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryDto;
        }
    }
}