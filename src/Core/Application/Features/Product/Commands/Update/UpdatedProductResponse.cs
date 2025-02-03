using Application.Responses;

namespace Application.Features.Product.Commands.Update;

public class UpdatedProductResponse : IResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
}