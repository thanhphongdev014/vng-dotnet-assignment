namespace Services.Product.Service.DTOs;

public class RemoveProductFromCartDto
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
