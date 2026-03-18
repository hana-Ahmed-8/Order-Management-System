using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Core.Entities
{
    public class Customer
    {
        [Key]
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = string.Empty;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public List<Order> Orders { get; set; } = new();
    }
}
