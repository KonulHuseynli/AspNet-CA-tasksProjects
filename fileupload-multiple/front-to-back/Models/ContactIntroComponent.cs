using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace front_to_back.Models
{
    public class ContactIntroComponent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mətn bölməsi mütləq doldurulmalıdır")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Mətn bölməsi mütləq doldurulmalıdır")]
        public string? Description { get; set; }

        public string? FilePath { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Fayl keçidi mütləq göstərilməlidir")]
        public IFormFile Photo { get; set; }

    }
}
