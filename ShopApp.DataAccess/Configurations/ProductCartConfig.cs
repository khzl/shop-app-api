using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Configurations
{
    public class ProductCartConfig : IEntityTypeConfiguration<ProductCarts>
    {
        public void Configure(EntityTypeBuilder<ProductCarts> builder)
        {
            // Composite Key
            builder.HasKey(productCart => new { productCart.ProductId, productCart.CartId });

            // Configure relationships 
            builder.HasOne(productCart => productCart.Products)
                .WithMany(product => product.ProductCarts)
                .HasForeignKey(productCart => productCart.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(productCart => productCart.Carts)
                .WithMany(Cart => Cart.ProductCarts)
                .HasForeignKey(productCart => productCart.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
