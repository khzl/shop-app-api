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
            builder.Property(product => product.Name).HasMaxLength(150).IsRequired();

            builder.OwnsOne(product => product.Price, productbuilder =>
            {
                productbuilder.Property(product => product.Value).HasColumnName("Price");
            });
        }
    }
}
