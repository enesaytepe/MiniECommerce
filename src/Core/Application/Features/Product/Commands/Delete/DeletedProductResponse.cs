using Application.Responses;

namespace Application.Features.Product.Commands.Delete;

public class DeletedProductResponse : IResponse
{
    public long Id { get; set; }
}