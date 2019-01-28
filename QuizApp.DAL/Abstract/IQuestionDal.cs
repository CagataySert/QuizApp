using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DAL.Abstract
{
    public interface IQuestionDal
    {
        Question GetQuestion(int _id);
        Question GetQuestion(Expression<Func<Question, bool>> predicate);
        List<Question> GetQuestions();
        List<Question> GetQuestions(Expression<Func<Question, bool>> predicate);
        bool AddOrUpdateQuestion(Question question);
        bool DeleteQuestion(int _id);
    }
}
