using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Entity
{
    public interface IGenericService<T>
    {
        T GetById(int _id);
        T GetById(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        bool AddOrUpdate(T entity);
        bool Delete(int _id);
    }
}
