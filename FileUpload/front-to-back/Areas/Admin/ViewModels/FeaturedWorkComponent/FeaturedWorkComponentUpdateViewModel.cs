using front_to_back.Models;

namespace front_to_back.Areas.Admin.ViewModels.FeaturedWorkComponent
{
    public class FeaturedWorkComponentUpdateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<Models.FeaturedWorkComponentPhoto> FeaturedWorkComponentPhotos { get; set; }

    }
}
