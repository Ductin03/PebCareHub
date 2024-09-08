using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Models.ResponUserModel
{
    public class UpdateUserRequestModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
