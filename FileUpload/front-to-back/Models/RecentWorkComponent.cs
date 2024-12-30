using System.ComponentModel.DataAnnotations;

namespace front_to_back.Models
{
    public class RecentWorkComponent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlıq yerini mütləq doldur."), MinLength(5, ErrorMessage = "Başlığın minumum uzunluğu 5 olmalıdır")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Mətn bölməsi mütləq doldurulmalıdır")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Fayl keçidi mütləq göstərilməlidir")]
        public string FilePath { get; set; }
    }
}