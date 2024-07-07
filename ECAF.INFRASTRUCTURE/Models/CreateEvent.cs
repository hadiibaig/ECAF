using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class CreateEvent
    {
        public string Title { get; set; }
        public string ScheduledDate { get; set; }
        public string ScheduledTime { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }

    }
}
