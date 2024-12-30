using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlowerProjectP323.Areas.Admin.ViewModels.Blog
{
    public class BlogIndexViewModel
    {
        public List<Models.Blog>? Blogs { get; set; }
    }
}
