using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Repositories;

namespace ShopApp.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ShopDbContext _Db;
        private bool _disposed = false;

        // Repositories 
        private ICustomerRepository? _customerRepository;
        private IProductRepository? _productRepository;
        private IOrderRepository? _orderRepository;
        private ICartRepository? _cartRepository;
        private ICategoryRepository? _categoryRepository;
        private IPaymentRepository? _paymentRepository;

        public UnitOfWork(ShopDbContext Db)
        {
            _Db = Db;
        }

        // lazy loading for Repositories 
        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_Db);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_Db);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_Db);
        public ICartRepository Carts => _cartRepository ??= new CartRepository(_Db);
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_Db);
        public IPaymentRepository Payments => _paymentRepository ??= new PaymentRepository(_Db);

        public int Save()
        {
            return _Db.SaveChanges(); 
        }

        public async Task<int> SaveAsync()
        {
            return await _Db.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _Db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _Db.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _Db.Database.RollbackTransaction(); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed && disposing)
            {
                _Db.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }

    }
}
