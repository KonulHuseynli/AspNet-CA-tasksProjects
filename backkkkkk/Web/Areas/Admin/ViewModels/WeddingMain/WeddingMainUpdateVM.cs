namespace Web.Areas.Admin.ViewModels.WeddingMain
{
    public class WeddingMainUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public string? MainPhotoPath { get; set; }
    }
}
