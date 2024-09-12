using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PebCareHub.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid SellerId { get; set; }
        public ICollection<Pet> Pet { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
