using FlowerProjectP323.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static FlowerProjectP323.Models.Product;

namespace FlowerProjectP323.Areas.Admin.ViewModels.Product
{

    public class ProductIndexViewModel
    {
        public List<Models.Product> Products { get; set; }

        #region filter

        public string? Title { get; set; }
        public List<SelectListItem> Categories { get; set; }
        [Display (Name ="Category")]
        public int? CategoryId { get; set; }

        [Display (Name ="Minimum Price")]
        public double? MinPrice { get; set; }
        [Display(Name ="Max Price")]
        public double? MaxPrice { get; set; }

        [Display(Name ="Min Quantity")]
        public int? MinQuantity { get; set; }
        [Display(Name ="Max Quantity")]
        public int? MaxQuantity { get; set; }

        [Display(Name ="Created Start date")]
        public DateTime? CreatedAtStart { get; set; }
        [Display(Name ="Created End date")]
        public DateTime? CreatedAtEnd { get; set; }
        public ProductStatus Status { get; set; }
        #endregion
    }
}