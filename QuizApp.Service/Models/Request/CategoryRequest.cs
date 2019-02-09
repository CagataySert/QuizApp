using QuizApp.Service.Models.Attribute;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Service.Models.Request
{
    public class CategoryRequest
    {
        public Authentication Authentication { get; set; }

        public Category Category { get; set; }
    }
}