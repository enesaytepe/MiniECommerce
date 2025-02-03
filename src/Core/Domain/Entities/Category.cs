namespace Domain.Entities;

public class Category : Entity<long>
{
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }

    public virtual Category? ParentCategory { get; set; }
    public virtual List<Category> SubCategories { get; set; }
    public virtual List<Product> Products { get; set; }
}