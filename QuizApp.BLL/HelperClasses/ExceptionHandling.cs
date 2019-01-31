using QuizApp.BLL.Utilities;
using QuizApp.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.BLL.HelperClasses
{
    public static class ExceptionHandling
    {
        public static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
