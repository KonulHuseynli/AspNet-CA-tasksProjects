namespace Web.Areas.Admin.ViewModels.BespokeInform
{
    public class BespokeInformCreateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile MainPhoto { get; set; }
    }
}
