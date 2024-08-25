using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Cart.EntityFrameworkCore.Models;

namespace Services.Cart.EntityFrameworkCore.MappingConfigurations;

public class ListItemEntryConfiguration : IEntityTypeConfiguration<ListItem>
{
    public void Configure(EntityTypeBuilder<ListItem> builder)
    {
        builder.ToTable("ListItems", "cart");
        builder.HasKey(x => new { x.ProductId, x.CardId });
        builder.HasOne(i => i.Cart)
               .WithMany(c => c.ListItems)
               .HasForeignKey(i => i.CardId);
    }
}
