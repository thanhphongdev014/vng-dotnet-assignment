namespace Services.Cart.EntityFrameworkCore.Models;

public class ListItem
{
    public Guid CardId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public CartModel? Cart { get; set; }
}
