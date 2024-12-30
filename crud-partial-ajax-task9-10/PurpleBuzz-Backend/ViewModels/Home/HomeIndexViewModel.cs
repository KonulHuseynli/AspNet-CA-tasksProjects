using PurpleBuzz_Backend.Models;

namespace PurpleBuzz_Backend.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public List<ProjectComponent> ProjectComponents { get; set; }
        public List<RecentWorkComponent> RecentWorkComponents { get; set; }
    }
}
