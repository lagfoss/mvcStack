using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackITmvc.Models
{
    public class Hardware
    {
        public int HardwareId { get; set; }

        [Display(Name = "Hardware Name")]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string HardwareName { get; set; }
    }
}
