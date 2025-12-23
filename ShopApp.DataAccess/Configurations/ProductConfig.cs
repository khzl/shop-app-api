using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;
using ShopApp.Models.Common;

namespace ShopApp.DataAccess.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(product => product.ProductId);

            builder.Property(product => product.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(product => product.Description)
                .HasMaxLength(1000);

            // Configure Price As Owned Entity 
            builder.OwnsOne(product => product.Price, priceBuilder =>
            {
                priceBuilder.Property(price => price.Value)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            });

            // Index For Name 
            builder.HasIndex(product => product.Name);

            // Foreign Key To Category 
            builder.HasOne(product => product.Categories)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many - To - Many with Carts through ProductCarts 
            builder.HasMany(product => product.ProductCarts)
                .WithOne(productCart => productCart.Products)
                .HasForeignKey(productCart => productCart.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // One - To - Many With orderItems 
            builder.HasMany(product => product.OrderItems)
                .WithOne(orderItem => orderItem.Product)
                .HasForeignKey(orderItem => orderItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
