



namespace E.Domain.Entites
{

    public class Cart
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        private List<CartItem> _items = new List<CartItem>();

        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

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

             
            _items.Add(new CartItem(productId, quantity));
            
        }

        public void RemoveItem(int productId)
        {


            if (productId <= 0)
                throw new ArgumentException("Ivalid Product Id .", nameof(productId));

             
            var item = Items.FirstOrDefault(item => item.ProductId == productId);

            if (item is null)
                throw new InvalidOperationException(
                    "Product does not exist in the cart.");
        
            
            _items.Remove(item);
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


        private CartItem GetItem (int productId)
        {
            if (productId <= 0)
                throw new ArgumentException(
                    "Invalid product ID.",
                    nameof(productId));

            var item = Items.FirstOrDefault(ite => ite.ProductId == productId);

            if(item is null)
                throw new InvalidOperationException(
                    "Product does not exist in the cart.");

            return item;
        }
    }

}
