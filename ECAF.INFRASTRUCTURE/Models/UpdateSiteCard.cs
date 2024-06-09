using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class UpdateSiteCard
    {
        public List<SiteCardCharge> SiteCardCharge { get; set; }
        public List<SiteCardCodes> SiteCardCodes { get; set; }
    }
}
