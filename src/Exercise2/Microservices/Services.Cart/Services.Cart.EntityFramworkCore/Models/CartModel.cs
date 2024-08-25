namespace Services.Cart.EntityFrameworkCore.Models;

public class CartModel
{
    public Guid Id { get; set; }
    public double TotalPrice { get; set; }
    public IList<ListItem> ListItems { get; set; } = new List<ListItem>();
}
