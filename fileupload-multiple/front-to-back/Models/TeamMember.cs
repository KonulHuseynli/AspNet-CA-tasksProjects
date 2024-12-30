using System.ComponentModel.DataAnnotations.Schema;

namespace front_to_back.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Position{ get; set; }
        public string? PhotoPath{ get; set; }

        [NotMapped]
        public IFormFile Photo{ get; set; } 
    }
}
