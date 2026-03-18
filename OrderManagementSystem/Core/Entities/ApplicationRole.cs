using Microsoft.AspNetCore.Identity;

namespace OrderManagementSystem.Core.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
