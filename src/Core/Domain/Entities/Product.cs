namespace Domain.Entities;

public class Product : Entity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockCount { get; set; }
    public double Price { get; set; }
    public long CategoryId { get; set; }

    public virtual Category Category { get; set; }
}