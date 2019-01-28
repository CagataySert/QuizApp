using QuizApp.DAL.Abstract;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DAL.Concrete.EntityFramework
{
    public class EfQuestionDal:IQuestionDal
    {
        private static EfQuestionDal _efQuestionDal;
        static object _lockObject = new object();

        private EfQuestionDal()
        {

        }

        public static EfQuestionDal CreateAsSingleton()
        {

            lock (_lockObject)
            {
                if (_efQuestionDal == null)
                {
                    _efQuestionDal = new EfQuestionDal();
                }
            }
            return _efQuestionDal;
        }

        QuizAppContext context = new QuizAppContext();        

        public bool DeleteQuestion(int _id)
        {
            Question willBeDeletedEntity = context.Questions.Where(s => s.Id == _id).FirstOrDefault();
            context.Questions.Remove(willBeDeletedEntity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public Question GetQuestion(int _id)
        {
            return context.Questions.Where(s => s.Id == _id).FirstOrDefault();
        }

        public Question GetQuestion(Expression<Func<Question, bool>> predicate)
        {
            return context.Questions.Where(predicate).FirstOrDefault();
        }

        public List<Question> GetQuestions()
        {
            return context.Questions.ToList();
        }

        public List<Question> GetQuestions(Expression<Func<Question, bool>> predicate)
        {
            return context.Questions.Where(predicate).ToList();
        }

        public bool AddOrUpdateQuestion(Question question)
        {
            context.Questions.AddOrUpdate(question);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
