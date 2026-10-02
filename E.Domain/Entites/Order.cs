using E.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Domain.Entites
{
    public class Order :BaseEntity
    {
        public int UserId { get; private set; }
         
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public decimal TotalAmount { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    
        
        
        private Order() { }
        public Order(int userId )
        {
            if(userId <= 0)
                throw new ArgumentException("Invalid user ID.", nameof(userId));
            UserId = userId;
            Status = OrderStatus.Pending;
        }


        public void AddItem(
        int productId,
        string productName,
        decimal unitPrice,
        int quantity)
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException(
                    "Items can only be added to a pending order.");

            if (OrderItems.Any(x => x.ProductId == productId))
                throw new InvalidOperationException(
                    "Product already exists in the order.");

            var item = new OrderItem(
                productId,
                productName,
                unitPrice,
                quantity);

            OrderItems.Add(item);

            RecalculateTotal();
            UpdatedAt = DateTime.UtcNow;
        }

        private void RecalculateTotal()
        {
            TotalAmount = OrderItems.Sum(item => item.TotalPrice);
        }

        public void StartProcessing()
        {
            if (Status != OrderStatus.Confirmed)
                throw new InvalidOperationException(
                    "Only confirmed orders can be processed.");

            Status = OrderStatus.Processing;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Ship()
        {
            if (Status != OrderStatus.Processing)
                throw new InvalidOperationException(
                    "Only processing orders can be shipped.");

            Status = OrderStatus.Shipped;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deliver()
        {
            if (Status != OrderStatus.Shipped)
                throw new InvalidOperationException(
                    "Only shipped orders can be delivered.");

            Status = OrderStatus.Delivered;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Confirm()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException(
                    "Only pending orders can be confirmed.");


            if (!OrderItems.Any())
                throw new InvalidOperationException(
                    "An order must contain at least one item.");

            Status = OrderStatus.Confirmed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Shipped ||
                Status == OrderStatus.Delivered)
            {
                throw new InvalidOperationException(
                    "This order cannot be cancelled.");
            }

            if (Status == OrderStatus.Cancelled)
            {
                throw new InvalidOperationException(
                    "Order is already cancelled.");
            }

            Status = OrderStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
    