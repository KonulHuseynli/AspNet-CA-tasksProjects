using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace front_to_back.Areas.Admin.ViewModels.CategoryComponent
{
    public class CategoryComponentUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Photo { get; set; }
        public string? PhotoPath { get; set; }
        [Display(Name = "category")]
        public int CategoryID { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
