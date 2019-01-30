using QuizApp.BLL.Concrete.CategoryManager;
using QuizApp.DAL.Concrete.EntityFramework;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dal = EfQuestionDal.CreateAsSingleton();
            var modelFromDb = dal.GetQuestionWithAnswersById(1);

            return View();
        }        
    }
}