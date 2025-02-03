using Application.Responses;

namespace Application.Features.Product.Commands.Create;

public class CreatedProductResponse : IResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
}