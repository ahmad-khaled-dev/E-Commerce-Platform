using E.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Domain.Entites
{

    public class Brand : BaseEntity
    {
        public string Name { get; private set; } = null!;

        public ICollection<Product> Products { get; private set; }
            = new List<Product>();

        private Brand() { }

        public Brand(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Brand name is required.",
                    nameof(name));

            Name = name.Trim();
        }

        public void Rename(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Brand name is required.",
                    nameof(name));

            Name = name.Trim();
        }
    }


}
