using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Entities.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTrue { get; set; }

        public int QuestionId { get; set; }
    }
}
