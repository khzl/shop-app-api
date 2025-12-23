using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Interfaces;

namespace ShopApp.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Property Get (Read Only)
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        ICartRepository Carts { get; }
        ICategoryRepository Categories { get; }
        IPaymentRepository Payments { get; }

        int Save();
        Task<int> SaveAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
