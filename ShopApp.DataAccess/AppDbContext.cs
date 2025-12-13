using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
