using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;
using ShopApp.Models.Common;

namespace ShopApp.DataAccess.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasKey(orderItem => orderItem.OrderItemId);

            builder.Property(orderItem => orderItem.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            // Configure Price As Owned Entity 
            builder.OwnsOne(orderItem => orderItem.UnitPrice, priceBuilder =>
            {
                priceBuilder.Property(price => price.Value)
                .HasColumnName("UnitPrice")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            });

            // Foreign Key To Order 
            builder.HasOne(orderItem => orderItem.Order)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // foreign Key To Product 
            builder.HasOne(orderItem => orderItem.Product)
                .WithMany(product => product.OrderItems)
                .HasForeignKey(orderItem => orderItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
