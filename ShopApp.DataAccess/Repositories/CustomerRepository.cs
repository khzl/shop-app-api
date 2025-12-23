using ShopApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;
using ShopApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopApp.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopDbContext _Db;
        public CustomerRepository(ShopDbContext Db)
        {
            _Db = Db;
        }

        public int Add(Customers customers)
        {
            _Db.Customers.Add(customers);
            _Db.SaveChanges();
            return customers.CustomerId;
        }

        public void Delete(int Id)
        {
            var customer = _Db.Customers.Find(Id);
            if (customer != null)
            {
                _Db.Customers.Remove(customer);
                _Db.SaveChanges();
            }
        }

        public List<Customers> GetAll()
        {
            return _Db.Customers
                .Include(customer => customer.Orders)
                .Include(customer => customer.Cart)
                .ToList();
        }

        public Customers? GetById(int Id)
        {
            return _Db.Customers.Find(Id);
        }

        public void Update(Customers customers)
        {
            _Db.Customers.Update(customers);
            _Db.SaveChanges();
        }

    }
}
