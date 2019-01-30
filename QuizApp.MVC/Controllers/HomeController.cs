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
            //var entity = new Category() { Id = 9, Level = "Medium", Name = "Zamazingo" };
            //var business = new CategoryManager(EfCategoryDal.CreateAsSingleton());           
            //var sonuc = business.GetAll();
            //try
            //{
            //    business.AddOrUpdate(entity);
            //}
            //catch (Exception exception)
            //{
            //    throw exception;
            //}           
            return View();
        }        
    }
}