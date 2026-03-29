using ECommerce.Domin.Entities.ProductModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Data.Configurations.ProductConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(X => X.Title)
                .HasMaxLength(100);
            builder.Property(X => X.Description)
                .HasMaxLength(500);
            builder.Property(X => X.Price)
                .HasPrecision(18, 2);
            builder.Property(X => X.PriceAfterDiscount)
                .HasPrecision(18, 2);


            builder.HasOne(X => X.Brand)
                .WithMany()
                .HasForeignKey(X => X.BrandId);

            builder.HasOne(X => X.Category)
                .WithMany()
                .HasForeignKey(X => X.CategoryId);
        }
    }
}
