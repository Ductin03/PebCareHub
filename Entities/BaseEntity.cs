using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        [Required]

        [MaxLength(250)]
        public DateTime CreateDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
