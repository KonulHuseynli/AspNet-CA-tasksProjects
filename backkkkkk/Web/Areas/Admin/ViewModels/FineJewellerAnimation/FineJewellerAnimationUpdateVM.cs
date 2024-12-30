namespace Web.Areas.Admin.ViewModels.FineJewellerAnimation
{
    public class FineJewellerAnimationUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? MainPhotoName { get; set; }
        public IFormFile? MainPhoto { get; set; }
    }
}
