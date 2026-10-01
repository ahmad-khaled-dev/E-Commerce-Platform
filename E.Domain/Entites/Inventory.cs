using E.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Domain.Entites
{

    public class Inventory 
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Product Product { get; private set; } = null!;

        private Inventory() { }

        public Inventory(int productId, int quantity)
        { 
            if(quantity <0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            ProductId = productId;
            Quantity = quantity;
        }


        public void Increase(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            Quantity += amount;
        }

        public bool Decrease(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (amount > Quantity)
                return false;

            Quantity -= amount;
            return true;
        }

    }


}
