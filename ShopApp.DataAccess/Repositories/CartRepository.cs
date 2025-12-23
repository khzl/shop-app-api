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
    public class CartRepository : ICartRepository
    {
        private readonly ShopDbContext _Db;

        public CartRepository(ShopDbContext db)
        {
            _Db = db;
        }

        public int Add(Carts Cart)
        {
            _Db.Carts.Add(Cart);
            _Db.SaveChanges();
            return Cart.CartId;
        }

        public void AddProductToCart(int CartId,int ProductId, int Quantity = 1)
        {
            var ExistingItem = _Db.ProductCarts.FirstOrDefault(productCart => productCart.CartId == CartId
            && productCart.ProductId == ProductId);

            if (ExistingItem == null)
            {
                var productCart = new ProductCarts
                {
                    CartId = CartId,
                    ProductId = ProductId
                };
                _Db.ProductCarts.Add(productCart);
            }
            _Db.SaveChanges();
        }

        public void ClearCart(int CartId)
        {
            var CartItems = _Db.ProductCarts
                .Where(productCart => productCart.CartId == CartId)
                .ToList();

            _Db.ProductCarts.RemoveRange(CartItems);
            _Db.SaveChanges();
        }

        public void Delete(int CartId)
        {
            var Cart = _Db.Carts.Find(CartId);
            if (Cart != null)
            {
                _Db.Carts.Remove(Cart);
                _Db.SaveChanges();
            }
        }

        public Carts? GetById(int cartId)
        {
            return _Db.Carts
                .Include(c => c.ProductCarts)
                .ThenInclude(pc => pc.Products)
                .FirstOrDefault(c => c.CartId == cartId);
        }

        public Carts? GetByCustomerId(int customerId)
        {
            return _Db.Carts
                .Include(cart => cart.ProductCarts)
                .ThenInclude(productCart => productCart.Products)
                .FirstOrDefault(cart => cart.CustomerId == customerId);
        }

        public List<ProductCarts> GetCartItems(int CartId)
        {
            return _Db.ProductCarts
                .Include(productCart => productCart.Products)
                .Where(productCart => productCart.CartId == CartId)
                .ToList();
        }

        public int GetCartItemCount(int CartId)
        {
            return _Db.ProductCarts
                .Count(productCart => productCart.CartId == CartId);
        }

        public void RemoveProductFromCart(int CartId , int ProductId)
        {
            var Item = _Db.ProductCarts
                .FirstOrDefault(productCart => productCart.CartId == CartId && productCart.ProductId == ProductId);

            if (Item != null)
            {
                _Db.ProductCarts.Remove(Item);
                _Db.SaveChanges();
            }
        }

        public void Update(Carts Cart)
        {
            _Db.Carts.Update(Cart);
            _Db.SaveChanges();
        }

        public decimal CalculateCartTotal(int CartId)
        {
            var Total = _Db.ProductCarts
                .Include(productCart => productCart.Products)
                .Where(productCart => productCart.CartId == CartId)
                .ToList()
                .Sum(productCart =>
                {
                    var Price = productCart.Products?.Price?.Value;
                    return Price ?? 0;
                });
            return Total;
        }
    }
}
