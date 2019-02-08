using QuizApp.Interfaces.AnswerService;
using QuizApp.Interfaces.QuestionService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.MVC.Controllers
{
    public class AnswerController : Controller
    {
        IAnswerService _answerService;
        IQuestionService _questionService;
        public AnswerController(IAnswerService answerService,IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        public JsonResult GetAnswersAndQuestion(int choosenAnswerId)
        {
            Answer answer = _answerService.GetById(choosenAnswerId);
            QuestionWithAnswers questionWithAnswers = _questionService.GetQuestionWithAnswersById(answer.QuestionId);
            return Json(questionWithAnswers,JsonRequestBehavior.AllowGet);
        }
    }
}