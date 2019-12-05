using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackITmvc.Models
{
    public class K_OperatorSubscriptions
    {
        public int K_OperatorId { get; set; }
        public K_Operator K_Operator { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
