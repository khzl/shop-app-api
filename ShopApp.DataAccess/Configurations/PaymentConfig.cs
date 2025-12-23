using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Configurations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.HasKey(payment => payment.PaymentId);

            builder.Property(payment => payment.PaymentId)
                .HasColumnName("Id"); // Keep The Same Column Name 

            builder.Property(payment => payment.TypePayment)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(payment => payment.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Foreign Key To Customer 
            builder.HasOne(payment => payment.Customer)
                .WithMany(customer => customer.Payments)
                .HasForeignKey(payment => payment.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Key To Order (One To One)
            builder.HasOne(payment => payment.Order)
                .WithOne(order => order.Payment)
                .HasForeignKey<Payments>(product => product.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
