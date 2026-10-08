using E.Domain.Common;



namespace E.Domain.Entites
{
    public class OrderItem :BaseEntity
     {
        public int OrderId { get; private set; }
        public Order Order { get; private set; } = null!;
        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;
        public string ProductName { get; private set; } = null!;
    
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public decimal TotalPrice =>UnitPrice * Quantity;
     
        
        
        private OrderItem() { }
          internal OrderItem(
          int productId,
          string productName,
          decimal unitPrice,
          int quantity)
        {
            if (productId <= 0)
                throw new ArgumentException(
                    "Invalid product ID.",
                    nameof(productId));

            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException(
                    "Product name is required.",
                    nameof(productName));

            if (unitPrice <= 0)
                throw new ArgumentException(
                    "Unit price must be greater than zero.",
                    nameof(unitPrice));

            if (quantity <= 0)
                throw new ArgumentException(
                    "Quantity must be greater than zero.",
                    nameof(quantity));

            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

       
    }

}
