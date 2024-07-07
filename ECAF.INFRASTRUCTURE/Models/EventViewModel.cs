using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class EventViewModel
    {
        public long Id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string className { get; set; }
    }
}
