using ShopApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Db;

        public UnitOfWork(AppDbContext Db,
            ICustomerRepository customers,
            IProductRepository products,
            IOrderRepository orders,
            ICartRepository carts)
        {
            _Db = Db;
            Customers = customers;
            Products = products;
            Orders = orders;
            Carts = carts;
        }

        // property get (read only)
        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public ICartRepository Carts { get; }
        public int Save() => _Db.SaveChanges();
    }
}
