using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Entities
{

    public class PetCategory : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}
