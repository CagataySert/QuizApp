using QuizApp.Service.Models.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Service.Models.Response
{
    public class CategoryResponse
    {
        public Status Status { get; set; }
        public int CategoryId { get; set; }
    }
}