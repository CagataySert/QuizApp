using QuizApp.BLL.Utilities;
using QuizApp.BLL.ValidationRules.FluentValidation;
using QuizApp.DAL.Abstract;
using QuizApp.Interfaces.QuestionService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.BLL.Concrete.QuestionManager
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _efQuestionDal;
        public QuestionManager(IQuestionDal efQuestionDal)
        {
            _efQuestionDal = efQuestionDal;
        }

        public bool AddOrUpdate(Question entity)
        {
            try
            {
                ValidationTool.Validate(new QuestionValidator(), entity);
                return _efQuestionDal.AddOrUpdateQuestion(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Delete(int _id)
        {
            return _efQuestionDal.DeleteQuestion(_id);
        }

        public List<Question> GetAll()
        {
            return _efQuestionDal.GetQuestions();
        }

        public List<Question> GetAll(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Question GetById(int _id)
        {
            return _efQuestionDal.GetQuestion(_id);
        }

        public Question GetById(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public QuestionWithAnswers GetQuestionWithAnswersById(int _id)
        {
            return _efQuestionDal.GetQuestionWithAnswersById(_id);
        }
    }
}
