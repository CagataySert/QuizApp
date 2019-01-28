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
    public class EfAnswerDal:IAnswerDal
    {
        private static EfAnswerDal _efAnswerDal;
        static Object _lockObject = new object();

        private EfAnswerDal()
        {

        }

        public static EfAnswerDal CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_efAnswerDal == null)
                {
                    _efAnswerDal = new EfAnswerDal();
                }
            }
            return _efAnswerDal;
        }

        QuizAppContext context = new QuizAppContext();

        public Answer GetAnswer(int _id)
        {
            return context.Answers.Where(s => s.Id == _id).FirstOrDefault();
        }

        public Answer GetAnswer(Expression<Func<Answer, bool>> predicate)
        {
            return context.Answers.Where(predicate).FirstOrDefault();
        }

        public List<Answer> GetAnswers()
        {
            return context.Answers.ToList();
        }

        public List<Answer> GetAnswers(Expression<Func<Answer, bool>> predicate)
        {
            return context.Answers.Where(predicate).ToList();
        }        

        public bool DeleteAnswer(int _id)
        {
            Answer willBeDeletedEntity = context.Answers.Where(s => s.Id == _id).FirstOrDefault();
            context.Answers.Remove(willBeDeletedEntity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool AddOrUpdateAnswer(Answer answer)
        {
            context.Answers.AddOrUpdate(answer);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
