using System.ComponentModel.DataAnnotations;

namespace PebCareHub.Models.ResponUserModel
{
    public class CreateRoleRequestModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string RoleName { get; set; }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }=false;

    }
}
