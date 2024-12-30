using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BespokeAnimation:BaseEntity
    {
        public string CoverImg { get; set; }

        public string VideoUrl { get; set; }
    }

}
