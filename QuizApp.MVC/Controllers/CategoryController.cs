using QuizApp.Interfaces.CategoryService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult GetAllCategories()
        {
            List<Category> categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}