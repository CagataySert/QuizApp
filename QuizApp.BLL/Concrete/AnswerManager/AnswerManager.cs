using QuizApp.BLL.Utilities;
using QuizApp.BLL.ValidationRules.FluentValidation;
using QuizApp.DAL.Abstract;
using QuizApp.Interfaces.AnswerService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.BLL.Concrete.AnswerManager
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _efAnswerDal;
        public AnswerManager(IAnswerDal efAnswerDal)
        {
            _efAnswerDal = efAnswerDal;
        }

        public bool AddOrUpdate(Answer entity)
        {
            try
            {
                ValidationTool.Validate(new AnswerValidator(),entity);
                return _efAnswerDal.AddOrUpdateAnswer(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Delete(int _id)
        {
            return _efAnswerDal.DeleteAnswer(_id);
        }

        public List<Answer> GetAll()
        {
            return _efAnswerDal.GetAnswers();
        }

        public List<Answer> GetAll(Expression<Func<Answer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetAnswerByQuestionId(int _id)
        {
            throw new NotImplementedException();
        }

        public Answer GetById(int _id)
        {
            return _efAnswerDal.GetAnswer(_id);
        }

        public Answer GetById(Expression<Func<Answer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
