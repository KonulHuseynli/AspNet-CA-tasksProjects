namespace WebApp.ViewModels.Doctor
{
    public class DoctorCreateVM
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Qualification { get; set; }
        public IFormFile Photo { get; set; }
    }
}
