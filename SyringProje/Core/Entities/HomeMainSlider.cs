using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class HomeMainSlider:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubPhotoName { get; set; }
        public ICollection<HomeMainSliderPhoto> HomeMainSliderPhotos { get; set; }
    }
}
