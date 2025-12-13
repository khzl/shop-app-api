using ShopApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {
        // signture for method
        Customers? GetById(int Id);
        List<Customers> GetAll();
        int Add(Customers customers);
        void Update(Customers customers);
        void Delete(int id);

    }
}
