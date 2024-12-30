using Core.Entities;

namespace WebApp.ViewModels.HomeMainSlider
{
    public class HomeMainSliderUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? SubPhoto { get; set; }
        public string? SubPhotoName { get; set; }
       
     
    }
}
