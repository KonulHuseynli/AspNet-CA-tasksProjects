using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace front_to_back.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Position { get; set; }
        public string? PhotoPath { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
