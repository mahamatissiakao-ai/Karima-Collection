using System.Collections.Generic;
using KarimaCollection.Models;
using System.Linq;
using static KarimaCollection.Components.Pages.Index;

namespace KarimaCollection.Data
{
    public class CartService
    {
        private List<CartItem> cartItems = new();

        public IReadOnlyList<CartItem> Items => cartItems.AsReadOnly();

        public void AddToCart(Product product)
        {
            var existing = cartItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = cartItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cartItems.Remove(item);
            }
        }

        public decimal GetTotal()
        {
            return cartItems.Sum(i => i.Price * i.Quantity);
        }

        public void ClearCart()
        {
            cartItems.Clear();
        }
    }
}
