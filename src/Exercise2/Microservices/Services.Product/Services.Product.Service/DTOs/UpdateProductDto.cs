namespace Services.Product.Service.DTOs;

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
}
