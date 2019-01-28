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
    public class EfCategoryDal:ICategoryDal
    {
        private static EfCategoryDal _efCategoryDal;
        static object _lockObject = new object();

        private EfCategoryDal()
        {

        }

        public static EfCategoryDal CreateAsSingleton()
        {
            lock(_lockObject)
            {
                if (_efCategoryDal == null)
                {
                    _efCategoryDal = new EfCategoryDal();
                }
            }
            return _efCategoryDal;
        }

        QuizAppContext context = new QuizAppContext();

        public bool DeleteCategory(int _id)
        {
            Category willBeDeletedEntity = context.Categories.Where(s => s.Id == _id).FirstOrDefault();
            context.Categories.Remove(willBeDeletedEntity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public List<Category> GetCategories(Expression<Func<Category, bool>> predicate)
        {
            return context.Categories.Where(predicate).ToList();
        }

        public Category GetCategory(int _id)
        {
            return context.Categories.Where(s => s.Id == _id).FirstOrDefault();
        }

        public Category GetCategory(Expression<Func<Category, bool>> predicate)
        {
            return context.Categories.Where(predicate).FirstOrDefault();
        }        
        
        public bool AddOrUpdateCategoryd(Category category)
        {
            context.Categories.AddOrUpdate(category);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
