using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackITmvc.Models.StackItViewModels
{
    public class AssignedJobData
    {
        public int JobId { get; set; }
        public String JobName { get; set; }
        public bool Assigned { get; set; }
    }
}
