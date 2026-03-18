using Microsoft.AspNetCore.Identity;

namespace OrderManagementSystem.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

        public Customer? Customer { get; set; }
        public Admin? Admin { get; set; }
    }
}
