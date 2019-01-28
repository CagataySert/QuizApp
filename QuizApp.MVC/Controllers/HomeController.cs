using QuizApp.DAL.Concrete.EntityFramework;
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
            var dal = EfCategoryDal.CreateAsSingleton();
            var categories = dal.GetCategories();

            return View();
        }        
    }
}