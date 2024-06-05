using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class CreateSiteCard
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public Customer Customer { get; set; }
        public FacilitiesManager FacilitiesManager { get; set; }
        public SiteCardAmount SiteCardAmount { get; set; }
        public List<SiteCardCharge> SiteCardCharge { get; set; }
    }
}
