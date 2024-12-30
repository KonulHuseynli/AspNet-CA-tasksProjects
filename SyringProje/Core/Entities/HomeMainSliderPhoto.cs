using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class HomeMainSliderPhoto:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Order { get; set; }
        public int HomeMainSliderId { get; set; }
        public HomeMainSlider HomeMainSlider { get; set; }
    }
}
