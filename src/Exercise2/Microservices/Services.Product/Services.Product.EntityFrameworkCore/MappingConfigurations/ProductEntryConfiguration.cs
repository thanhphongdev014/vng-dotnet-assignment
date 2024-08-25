using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Product.EntityFrameworkCore.Models;

namespace Services.Product.EntityFrameworkCore.MappingConfigurations;

public class ProductEntryConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.ToTable("Products", "product");
    }
}
