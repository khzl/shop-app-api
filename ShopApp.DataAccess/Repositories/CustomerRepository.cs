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

        public void Delete(int CustomerId)
        {
            var customer = _Db.Customers.Find(CustomerId);
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

        public Customers? GetById(int CustomerId)
        {
            try
            {
                return _Db.Customers
                    .AsSplitQuery()
                    .Include(customer => customer.Orders)
                    .ThenInclude(order => order.OrderItems)
                    .Include(customer => customer.Cart)
                    .ThenInclude(cart => cart != null ? cart.ProductCarts : Enumerable.Empty<ProductCarts>())
                    .ThenInclude(productCart => productCart != null ? productCart.Products : null)
                    .FirstOrDefault(customer => customer.CustomerId == CustomerId);
            }
            catch (Exception ex)
            {
                // log the error 
                Console.WriteLine($"Error Getting Customer By ID : {ex.Message}");
                return null;
            }
        }

        public Customers? GetByEmail(string Email)
        {
            return _Db.Customers
                .FirstOrDefault(customer => customer.Email == Email);
        }

        public void Update(Customers Customer)
        {
            var ExistingCustomer = _Db.Customers.Find(Customer.CustomerId);
            if(ExistingCustomer != null)
            {
                _Db.Entry(ExistingCustomer).CurrentValues.SetValues(Customer);
                _Db.SaveChanges();
            }
        }

        public bool CustomerExists(int CustomerId)
        {
            return _Db.Customers.Any(customer => customer.CustomerId == CustomerId);
        }

    }
}
