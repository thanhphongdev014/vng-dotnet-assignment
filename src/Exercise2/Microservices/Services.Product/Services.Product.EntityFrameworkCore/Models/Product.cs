namespace Services.Product.EntityFrameworkCore.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
}
