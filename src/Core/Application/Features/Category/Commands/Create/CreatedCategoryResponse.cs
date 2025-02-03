using Application.Responses;

namespace Application.Features.Category.Commands.Create;

public class CreatedCategoryResponse : IResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
}