using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Models
{
    public class SaveFormModel
    {
        public long FormId { get; set; }
        public string UserId { get; set; }
        public string PdfPath { get; set; }
        public List<QuestionAnswer> QuestionsAnswers { get; set; }

    }

    public class QuestionAnswer
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
