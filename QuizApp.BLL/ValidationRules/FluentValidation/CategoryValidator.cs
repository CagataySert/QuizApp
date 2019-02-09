using FluentValidation;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.BLL.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Level).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();

            //RuleFor(c => c.Name).Must(StartsWithA).WithMessage("A ile Başlamalı");
        }
        //private bool StartsWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
