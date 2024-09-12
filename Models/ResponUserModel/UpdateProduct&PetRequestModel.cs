namespace PebCareHub.Models.ResponUserModel
{
    public class UpdateProduct_PetRequestModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Decimal Price { get; set; }
        public int StockQuanlity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
