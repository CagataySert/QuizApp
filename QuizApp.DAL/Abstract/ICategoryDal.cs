using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DAL.Abstract
{
    public interface ICategoryDal
    {
        Category GetCategory(int _id);
        Category GetCategory(Expression<Func<Category, bool>> predicate);
        List<Category> GetCategories();
        List<Category> GetCategories(Expression<Func<Category,bool>> predicate);
        bool AddOrUpdateCategoryd(Category category);
        bool DeleteCategory(int _id);
    }
}
