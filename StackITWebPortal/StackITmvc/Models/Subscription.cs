using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackITmvc.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        [Display(Name = "Subscription Name")]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string SubscriptionName { get; set; }

        [Display(Name = "Company")]
        public int CustomerId { get; set; }

        public Customer Company { get; set; }

        [Display(Name = "Hardware")]
        public int HardwareId { get; set; }

        public Hardware Hardware { get; set; }

        public ICollection<SubscriptionJobs> SubscriptionJobs { get; set; }
        public ICollection<K_AdminSubscriptions> K_AdminSubscriptions { get; set; }
        public ICollection<K_OperatorSubscriptions> K_OperatorSubscriptions { get; set; }

    }
}
