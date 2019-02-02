using QuizApp.BLL.Concrete.AnswerManager;
using QuizApp.BLL.Concrete.CategoryManager;
using QuizApp.DAL.Concrete.EntityFramework;
using QuizApp.Interfaces.CategoryService;
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
        ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            //AnswerManager bll = new AnswerManager(EfAnswerDal.CreateAsSingleton());
            //bll.GetById(s => s.QuestionId == 1);

            //var result = bll.GetById(20);

            //var dal = EfAnswerDal.CreateAsSingleton();
            //var answers = dal.GetAnswers(s => s.QuestionId == 1);
            return View();
        }

        public ActionResult LoginPage()
        {
            List<Category> categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}