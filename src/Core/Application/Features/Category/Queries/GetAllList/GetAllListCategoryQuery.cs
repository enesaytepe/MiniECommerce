using Application.Features.Category.Queries.GetList;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Paging;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Category.Queries.GetAllList;

public class GetAllListCategoryQuery : IRequest<GetListResponse<GetAllListCategoryItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetAllListCategoryQueryHandler
        : IRequestHandler<GetAllListCategoryQuery, GetListResponse<GetAllListCategoryItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetAllListCategoryItemDto>> Handle(
            GetAllListCategoryQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Domain.Entities.Category> categories = await _categoryRepository.GetListAsync(
                 predicate: c => c.ParentCategoryId == null,
                 include: query => query.Include(c => c.SubCategories),
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
             );

            var mappedCategoryListModel = _mapper.Map<GetListResponse<GetAllListCategoryItemDto>>(categories);
            return mappedCategoryListModel;
        }
    }
}