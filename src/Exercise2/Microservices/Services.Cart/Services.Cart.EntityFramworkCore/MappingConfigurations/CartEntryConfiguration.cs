using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Cart.EntityFrameworkCore.Models;

namespace Services.Cart.EntityFrameworkCore.MappingConfigurations;

public class CartEntryConfiguration : IEntityTypeConfiguration<CartModel>
{
    public void Configure(EntityTypeBuilder<CartModel> builder)
    {
        builder.ToTable("Carts", "cart");
    }
}
