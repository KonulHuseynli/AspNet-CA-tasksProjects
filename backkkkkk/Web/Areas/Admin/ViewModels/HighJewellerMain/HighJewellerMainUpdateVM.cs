namespace Web.Areas.Admin.ViewModels.HighJewellerMain
{
    public class HighJewellerMainUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public string? MainPhotoPath { get; set; }
    }
}
