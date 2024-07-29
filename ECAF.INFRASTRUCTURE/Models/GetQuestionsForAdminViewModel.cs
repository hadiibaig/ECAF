using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
   public class GetQuestionsForAdminViewModel
    {
        public string UserId { get; set; }
        public List<string> Questions { get; set; }

        public bool IsQuestionsAvailable { get; set; }
    }
}
