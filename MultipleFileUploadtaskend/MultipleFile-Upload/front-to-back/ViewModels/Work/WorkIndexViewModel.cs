using front_to_back.Models;

namespace front_to_back.ViewModels.Work
{
    public class WorkIndexViewModel
    {
        public List<Category> Categories { get; set; }
        public FeaturedWorkComponent FeaturedWorkComponent { get; set; }
    }
}
