using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WhatWeDoBestPhoto:BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public int WhatNeedId { get; set; }


        public WhatWeDoBest WhatWeDoBest { get; set; }
    }
}
