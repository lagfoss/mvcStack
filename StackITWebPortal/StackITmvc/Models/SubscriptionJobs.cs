using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackITmvc.Models
{
    public class SubscriptionJobs
    {
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
