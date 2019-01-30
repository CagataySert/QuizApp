using FluentValidation;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.BLL.ValidationRules.FluentValidation
{
    public class QuestionValidator:AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.Id).NotEmpty();
            RuleFor(q => q.Name).NotEmpty();
            RuleFor(q => q.CategoryId).NotEmpty();
            RuleFor(q => q.Answers).NotEmpty();
        }
    }
}
