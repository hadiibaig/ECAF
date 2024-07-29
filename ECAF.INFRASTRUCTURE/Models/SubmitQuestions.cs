using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public  class SubmitQuestions
    {
        public List<string> Questions { get; set; }

        public string UserId { get; set; }
        public long FormId { get; set; }
    }

    //public class UsersQuestion
    //{
    //    public List<string> UserIds { get; set; }
    //    public string Question { get; set; }
    //}
}
