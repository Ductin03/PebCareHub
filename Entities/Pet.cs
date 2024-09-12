using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Entities
{
    public class Pet : BaseEntity
    {
        [MaxLength(250)]
        [Required]
        public string PetName { get; set; }
        public string Description { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public Guid SellerId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public PetCategory PetCategory { get; set; }
        public User Seller { get; set; }


    }
}
