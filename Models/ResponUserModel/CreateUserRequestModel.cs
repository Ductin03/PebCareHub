namespace PebCareHub.Models.ResponUserModel
{
    public class CreateUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name {  get; set; }
        public string Email { get; set; }   
        public Guid RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
