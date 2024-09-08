using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Entities
{
    public class Custormer
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UsersName {  get; set; }
        [Required]
        public string PassWord {  get; set; }

    }
}
