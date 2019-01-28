using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Entities.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Answer> Answers { get; set; }
        public int CategoryId { get; set; }
    }
}
