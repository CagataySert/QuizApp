using QuizApp.Interfaces.QuestionService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.MVC.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;            
        }

        public ActionResult Question(int categoryId)
        {
            List<QuestionWithAnswers> questions = _questionService.GetAllQuestionWithAnswersByCategoryId(categoryId);

            return View(questions);
        }        
    }
}