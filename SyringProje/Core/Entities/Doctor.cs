using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor:BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Qualification { get; set; }

        public string Photo { get; set; }

    }
}
