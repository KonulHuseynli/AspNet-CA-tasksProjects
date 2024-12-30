namespace WebApp.ViewModels.Doctor
{
    public class DoctorUpdateVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Qualification { get; set; }
        public IFormFile? Photo { get; set; }
        public string? PhotoName { get; set; }

    }
}
