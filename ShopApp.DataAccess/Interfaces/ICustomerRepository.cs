using ShopApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {
        // signature for method

        public int Add(Customers Customer);
        public void Delete(int CustomerId);
        public List<Customers> GetAll();
        public Customers? GetById(int CustomerId);
        public Customers? GetByEmail(string Email);
        public void Update(Customers Customer);
        public bool CustomerExists(int CustomerId);

    }
}
