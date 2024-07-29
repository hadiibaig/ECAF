using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class ApprovalFormViewModel
    {
        public long FormId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
