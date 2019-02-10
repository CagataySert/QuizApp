using QuizApp.Service.Models.Attribute;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Service.Models.Response
{
    public class CategoryResponse
    {
        public Status status { get; set; }
        public Category category { get; set; }
        public List<Category> categories { get; set; }
    }
}