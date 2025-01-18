using Developer.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.ProductId);
        builder.Property(p => p.ProductId).IsRequired();

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Discount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(p => p.CreatedAt).IsRequired();
    }
}
