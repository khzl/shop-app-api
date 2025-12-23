using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models.Model;
using ShopApp.DataAccess.Configurations;

namespace ShopApp.DataAccess.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Customers> Customers => Set<Customers>();
        public DbSet<Products> Products => Set<Products>();
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<OrderItems> OrderItems => Set<OrderItems>();
        public DbSet<Carts> Carts => Set<Carts>();
        public DbSet<Categories> Categories => Set<Categories>();
        public DbSet<Payments> Payments => Set<Payments>();
        public DbSet<ProductCarts> ProductCarts => Set<ProductCarts>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply All Configurations
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new CartConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCartConfig());

        }
    }
}
