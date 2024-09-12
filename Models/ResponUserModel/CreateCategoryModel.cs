namespace PebCareHub.Models.ResponUserModel
{
    public class CreateCategoryModel
    {
        public Guid IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid CreateBy { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
