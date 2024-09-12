using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(250)]     
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public string ImageUrl {  get; set; }
        public Guid SellerId { get; set; }
        public Guid CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public User Seller {  get; set; }
    }
}
