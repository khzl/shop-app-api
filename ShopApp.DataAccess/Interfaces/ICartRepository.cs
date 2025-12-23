using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Interfaces
{
    public interface ICartRepository
    {
        // Signature Method 

        Carts? GetById(int cartId);
        Carts? GetByCustomerId(int customerId);
        int Add(Carts Cart);
        void Update(Carts Cart);
        void Delete(int CartId);
        void AddProductToCart(int CartId, int ProductId, int Quantity = 1);
        void RemoveProductFromCart(int CartId, int ProductId);
        void ClearCart(int CartId);
        decimal CalculateCartTotal(int CartId);
        int GetCartItemCount(int CartId);
        List<ProductCarts> GetCartItems(int CartId);
    }
}
