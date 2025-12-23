using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Interfaces
{
    public interface IPaymentRepository
    {
        // Signature For Methods
        Payments? GetById(int PaymentId);
        List<Payments> GetAll();
        List<Payments> GetByCustomerId(int CustomerId);
        List<Payments> GetByOrderId(int OrderId);
        int Add(Payments payments);
        void Update(Payments payments);
        void Delete(int PaymentId);
        decimal GetTotalPaymentsByCustomer(int CustomerId);
        List<Payments> GetPaymentsByType(string PaymentType);
    }
}
