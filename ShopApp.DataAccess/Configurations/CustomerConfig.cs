using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(customer => customer.CustomerId);

            builder.Property(customer => customer.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(customer => customer.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(customer => customer.Password)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(customer => customer.EncryptedEmail)
                .HasMaxLength(255);

            // Index For Email
            builder.HasIndex(customer => customer.Email)
                .IsUnique();

            // One - To - One 
            builder.HasOne(customer => customer.Cart)
                .WithOne(customer => customer.Customer)
                .HasForeignKey<Carts>(customer => customer.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // One - To - Many 
            builder.HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // One - To - Many
            builder.HasMany(customer => customer.Payments)
                .WithOne(payment => payment.Customer)
                .HasForeignKey (payment => payment.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
