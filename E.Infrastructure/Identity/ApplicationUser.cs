using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure.Identity
{
    public class ApplicationUser :IdentityUser<int>
     {
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;

        public int ?CartId { get;private set; }
        public Cart? Cart { get; private set; }

        public ICollection<Order> Orders { get; private set; }
       = new List<Order>();
         
        public ApplicationUser(
        string firstName,
        string lastName,
        string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(
                    "First name is required.",
                    nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(
                    "Last name is required.",
                    nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            
            UserName = email;
        }
    }
}
