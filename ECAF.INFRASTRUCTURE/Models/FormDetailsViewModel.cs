using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
   public class FormDetailsViewModel
    {
        public Form Form { get; set; }
        public List<Comment> Comments { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<Question> Questions { get; set; }

    }
}
