using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Interfaces;
using ShopApp.Models.Model;
using ShopApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopApp.DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ShopDbContext _Db;

        public PaymentRepository(ShopDbContext Db)
        {
            _Db = Db;
        }

        public int Add(Payments payments)
        {
            _Db.Payments.Add(payments);
            _Db.SaveChanges();
            return payments.PaymentId;
        }

        public void Delete(int PaymentId)
        {
            var Payment = _Db.Payments.Find(PaymentId);
            if(Payment != null)
            {
                _Db.Payments.Remove(Payment);
                _Db.SaveChanges();
            }
        }

        public List<Payments> GetAll()
        {
            return _Db.Payments
                .Include(payment => payment.Customer)
                .Include(payment => payment.Order)
                .ToList();
        }

        public Payments? GetById(int PaymentId)
        {
            return _Db.Payments
                .Include(payment => payment.Customer)
                .Include(payment => payment.Order)
                .FirstOrDefault(payment => payment.PaymentId == PaymentId);
        }

        public List<Payments> GetByCustomerId(int CustomerId)
        {
            return _Db.Payments
                .Include(payment => payment.Customer)
                .Include(payment => payment.Order)
                .Where(payment => payment.CustomerId == CustomerId)
                .ToList();
        }

        public List<Payments> GetByOrderId(int OrderId)
        {
            return _Db.Payments
                .Include(payment => payment.Customer)
                .Include(payment => payment.Order)
                .Where(payment => payment.OrderId == OrderId)
                .ToList();
        }

        public List<Payments> GetPaymentsByType(string PaymentType)
        {
            return _Db.Payments
                .Include(payment => payment.Customer)
                .Include(payment => payment.Order)
                .Where(payment => payment.TypePayment == PaymentType)
                .ToList();
        }

        public decimal GetTotalPaymentsByCustomer(int CustomerId)
        {
            return _Db.Payments
                .Where(payment => payment.CustomerId == CustomerId)
                .Sum(payment => payment.Amount);
        }

        public void Update(Payments payments)
        {
            _Db.Payments.Update(payments);
            _Db.SaveChanges();
        }

    }
}
