namespace Web.Areas.Admin.ViewModels.BespokeInform
{
    public class BespokeInformUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? MainPhotoName { get; set; }
        public IFormFile? MainPhoto { get; set; }
    }
}
