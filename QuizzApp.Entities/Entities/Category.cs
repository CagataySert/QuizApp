using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Entities.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public List<Question> Questions { get; set; }
    }
}
