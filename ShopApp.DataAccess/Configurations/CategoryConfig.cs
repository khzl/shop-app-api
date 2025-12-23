using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(category => category.CategoryId);

            builder.Property(category => category.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(category => category.CategoryDescription)
                .HasMaxLength(500);

            builder.Property(category => category.PictureUrl)
                .HasMaxLength(500);

            // Index for CategoryName 
            builder.HasIndex(category => category.CategoryName);

            // One - To - Many With Products 
            builder.HasMany(category => category.Products)
                .WithOne(product => product.Categories)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
