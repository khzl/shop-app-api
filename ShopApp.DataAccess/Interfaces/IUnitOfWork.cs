using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        // Property get (read only)
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }

        ICartRepository Carts { get; }
        int Save();
    }
}
