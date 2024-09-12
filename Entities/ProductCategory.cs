using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Entities
{
    public class ProductCategory :BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
