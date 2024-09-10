using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PebCareHub.Entities
{
    public class Role :BaseEntity
    {

        [MaxLength(250)]
        [Required]
        public string RoleName { get; set; }

        public string Description { get; set; }
        public List<User> Users { get; set;}=new List<User>();

    }

}
