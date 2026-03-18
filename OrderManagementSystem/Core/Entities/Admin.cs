using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Core.Entities
{
    public class Admin
    {
        [Key]
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
