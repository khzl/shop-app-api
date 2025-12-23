using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(order => order.OrderId);

            builder.Property(order => order.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(order => order.OrderDate)
                .IsRequired();

            // Foreign Key to Customer 
            builder.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // One - To - One With Payment 
            builder.HasOne(order => order.Payment)
                .WithOne(payment => payment.Order)
                .HasForeignKey<Payments>(payment => payment.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // One - To - Many With OrderItems
            builder.HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
