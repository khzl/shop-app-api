using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Interfaces;
using ShopApp.Models.Model;
using ShopApp.Models.DTOs;
using ShopApp.BusinessLogic.Interfaces;

namespace ShopApp.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(CustomerDTO customerDTO)
        {
            var customer = new Customers
            {
                Name = customerDTO.CustomerName,
                Email = customerDTO.Email
            };
            return _unitOfWork.Customers.Add(customer);
        }

        public List<Customers> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }



    }
}
