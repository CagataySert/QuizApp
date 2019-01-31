using QuizApp.BLL.Concrete.AnswerManager;
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
            AnswerManager bll = new AnswerManager(EfAnswerDal.CreateAsSingleton());

            var result = bll.AddOrUpdate(new Answer() {  QuestionId = 2 });

            //var dal = EfAnswerDal.CreateAsSingleton();
            //var answers = dal.GetAnswers(s => s.QuestionId == 1);    
            return View();
        }        
    }
}