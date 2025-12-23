using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<Carts>
    {
        public void Configure(EntityTypeBuilder<Carts> builder)
        {
            builder.HasKey(cart => cart.CartId);

            // Foreign Key To Customer 
            builder.HasOne(cart => cart.Customer)
                .WithOne(customer => customer.Cart)
                .HasForeignKey<Carts>(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many - to - Many With Products Through ProductCarts
            builder.HasMany(cart => cart.ProductCarts)
                .WithOne(productCart => productCart.Carts)
                .HasForeignKey(productCart => productCart.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
