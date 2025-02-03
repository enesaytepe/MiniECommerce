using Application.Dtos;

namespace Application.Features.Product.Queries.GetList;

public class GetAllListProductItemDto : IDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockCount { get; set; }
    public double? Price { get; set; }
    public long CategoryId { get; set; }
}