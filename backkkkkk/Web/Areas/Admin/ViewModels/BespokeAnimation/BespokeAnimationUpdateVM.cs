namespace Web.Areas.Admin.ViewModels.BespokeAnimation
{
    public class BespokeAnimationUpdateVM
    {
        public int Id { get; set; }
        public IFormFile? CoverPhoto { get; set; }
        public string? MainPhotoPath { get; set; }

        public string VideoUrl { get; set; }
    }
}
