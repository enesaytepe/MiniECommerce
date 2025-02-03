using Application.Dtos;

namespace Application.Features.Category.Queries.GetList;

public class GetAllListCategoryItemDto : IDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long ParentCategoryId { get; set; }
    public List<GetAllListCategoryItemDto>? SubCategories { get; set; }
}