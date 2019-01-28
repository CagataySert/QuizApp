using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DAL.Abstract
{
    public interface IAnswerDal
    {
        Answer GetAnswer(int _id);
        Answer GetAnswer(Expression<Func<Answer, bool>> predicate);
        List<Answer> GetAnswers();
        List<Answer> GetAnswers(Expression<Func<Answer, bool>> predicate);
        bool AddOrUpdateAnswer(Answer answer);
        bool DeleteAnswer(int _id);
    }
}
