using Application.Responses;

namespace Application.Features.Product.Queries.GetById;

public class GetByIdProductResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
