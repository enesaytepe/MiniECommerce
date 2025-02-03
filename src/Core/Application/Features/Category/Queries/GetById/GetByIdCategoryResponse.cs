using Application.Responses;

namespace Application.Features.Category.Queries.GetById;

public class GetByIdCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
