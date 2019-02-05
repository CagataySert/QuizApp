using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Entities.Entities
{
    public class QuestionWithAnswers
    {
        public int QuestionId { get; set; }
        public List<int> AnswerIds { get; set; }
        public List<string> AnswerNames { get; set; }
        public string QuestionName { get; set; }
        public List<bool> AnswerType { get; set; }
    }
}
