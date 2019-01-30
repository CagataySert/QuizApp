using FluentValidation;
using QuizApp.BLL.Utilities;
using QuizApp.BLL.ValidationRules.FluentValidation;
using QuizApp.DAL.Abstract;
using QuizApp.DAL.Concrete.EntityFramework;
using QuizApp.Interfaces.CategoryService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuizApp.BLL.Concrete.CategoryManager
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _efCategoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _efCategoryDal = categoryDal;
        }
        public bool AddOrUpdate(Category entity)
        {            
            try
            {
                ValidationTool.Validate(new CategoryValidator(), entity);
                return _efCategoryDal.AddOrUpdateCategoryd(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Delete(int _id)
        {
            return _efCategoryDal.DeleteCategory(_id);
        }

        public List<Category> GetAll()
        {
            return _efCategoryDal.GetCategories();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int _id)
        {
            return _efCategoryDal.GetCategory(_id);
        }

        public Category GetById(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
