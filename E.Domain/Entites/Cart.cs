using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Domain.Entites
{

    public class Cart
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public ICollection<CartItem> Items { get; private set; }
            = new List<CartItem>();

        private Cart()
        {
        }

        public Cart(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException(
                    "Invalid user ID.",
                    nameof(userId));

            UserId = userId;
        }



        public void AddItem(int productId, int quantity)
        {


            if (productId <= 0)
                throw new ArgumentException("Ivalid Product Id .", nameof(productId));

            if (quantity <= 0)
                throw new ArgumentException(
                  "Quantity must be greater than zero.",
                  nameof(quantity));

           var existingItem=  Items.FirstOrDefault(item => item.ProductId == productId);

                if(existingItem is not  null)
            {  
            existingItem.IncreaseQuantity (quantity);
                return;
            }

             
            Items.Add(new CartItem(productId, quantity));
            
        }

        public void RemoveItem(int productId)
        {


            if (productId <= 0)
                throw new ArgumentException("Ivalid Product Id .", nameof(productId));

             
            var item = Items.FirstOrDefault(item => item.ProductId == productId);

            if (item is null)
                throw new InvalidOperationException(
                    "Product does not exist in the cart.");
        
            
            Items.Remove(item);
         }


        public void IncreaseItemQuantity(int productId, int quantity)
        {
            var item = GetItem(productId);

            item.IncreaseQuantity(quantity);
        }

        public void DecreaseItemQuantity(int productId, int quantity)
        {
            var item = GetItem(productId);

            item.DecreaseQuantity(quantity);
        }


        public CartItem GetItem (int productId)
        {
            var item = Items.FirstOrDefault(ite => ite.Id == productId);

            if(item is null)
                throw new InvalidOperationException(
                    "Product does not exist in the cart.");

            return item;
        }
    }
}
