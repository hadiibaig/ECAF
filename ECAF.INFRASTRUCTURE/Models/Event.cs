using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public string StatusString { get; set; }
        public string StatusColor { get; set; }
        public string className { get; set; }
    }
}
