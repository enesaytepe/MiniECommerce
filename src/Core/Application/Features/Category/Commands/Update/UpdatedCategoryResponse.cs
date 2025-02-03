using Application.Responses;

namespace Application.Features.Category.Commands.Update;

public class UpdatedCategoryResponse : IResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
}