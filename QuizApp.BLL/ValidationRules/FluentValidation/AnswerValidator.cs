using FluentValidation;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.BLL.ValidationRules.FluentValidation
{
    public class AnswerValidator:AbstractValidator<Answer>
    {
        public AnswerValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.QuestionId).NotEmpty();
        }
    }
}
