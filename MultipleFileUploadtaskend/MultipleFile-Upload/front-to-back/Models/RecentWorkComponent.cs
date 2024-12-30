using System.ComponentModel.DataAnnotations;

namespace front_to_back.Models
{
    public class RecentWorkComponent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad mutleq doldurumalidir"), MinLength(3, ErrorMessage = "Adin uzunluqu minimum 3 olmalidir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Text mutleq doldurumalidir"), MinLength(10, ErrorMessage = "Text uzunluqu minimum 10 olmalidir")]
        public string Text { get; set; }
        [Required(ErrorMessage = "FilePath mutleq doldurumalidir")]
        public string FilePath { get; set; }
    }
}
