using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackITmvc.Models
{
    public class Job
    {
        public int JobId { get; set; }

        [Display(Name = "Job Name")]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string JobName { get; set; }

        public ICollection<SubscriptionJobs> SubscriptionJobs { get; set; }

    }
}
