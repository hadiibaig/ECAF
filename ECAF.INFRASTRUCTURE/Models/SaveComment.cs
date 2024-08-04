using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
   public class SaveComment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public List<string> NotifyUsers { get; set; }
    }
}
