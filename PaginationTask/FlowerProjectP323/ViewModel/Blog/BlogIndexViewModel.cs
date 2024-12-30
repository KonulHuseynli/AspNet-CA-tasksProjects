
namespace FlowerProjectP323.ViewModel.Blog
{
    public class BlogIndexViewModel
    {
        public List<Models.Blog> Blogs { get; set; }
        public int Page { get; set; } = 1;

        public int Take { get; set; } = 2;

        public int PageCount { get; set; }
    }
}
