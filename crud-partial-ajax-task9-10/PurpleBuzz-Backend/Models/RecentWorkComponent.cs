using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_Backend.Models
{
    public class RecentWorkComponent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can't be null"), MinLength(3, ErrorMessage = "Title must contain 3 letter at least")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Text can't be null")]
        public string Text { get; set; }

        [Required(ErrorMessage = "FilePath can't be null")]
        public string FilePath { get; set; } 
    }
}
