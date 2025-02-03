using Application.Responses;

namespace Application.Features.Category.Commands.Delete;

public class DeletedCategoryResponse : IResponse
{
    public long Id { get; set; }
}