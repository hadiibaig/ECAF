using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
   public class DashboardViewModel
    {
        public List<Comment> Comments { get; set; }
        public List<SiteCard> SiteCards { get; set; }
    }
}
