using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class SettingsViewModel
    {
        public List<string> Roles { get; set; }
        public List<Form> Forms { get; set; }
        public List<AspNetUser> Users { get; set; }
    }
}
