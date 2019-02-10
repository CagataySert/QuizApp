using QuizApp.Interfaces.QuestionService;
using QuizApp.Service.HelperClass;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApp.Service.Controllers
{
    [Authorize]
    public class QuestionController : ApiController
    {
        IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IHttpActionResult GetById(int _id)
        {
            Question question = _questionService.GetById(_id);
            if (question == null)
            {
                return BadRequest("The entity could not be found by id");
            }
            else
            {
                return Ok(question);
            }
        }

        public IHttpActionResult GetAll()
        {
            List<Question> questions = _questionService.GetAll();
            return Ok(questions);
        }

        [HttpPost]
        public IHttpActionResult AddQuestion([FromBody]Question entity)
        {
            bool isAdded = _questionService.AddOrUpdate(entity);
            if (isAdded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int _id)
        {
            bool isDeleted = _questionService.Delete(_id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest("The entity could not be found by id");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateQuestion([FromBody]Question entity)
        {
            bool isUpdated = _questionService.AddOrUpdate(entity);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetAllQuestionWithAnswersByCategoryId(int _id)
        {
            List<QuestionWithAnswers> questions = _questionService.GetAllQuestionWithAnswersByCategoryId(_id);
            if (questions == null)
            {
                return BadRequest("The entity could not be found by id");
            }
            else
            {
                return Ok(questions);
            }
        }

        public IHttpActionResult GetQuestionWithAnswer(int _id)
        {
            QuestionWithAnswers question = _questionService.GetQuestionWithAnswersById(_id);
            if (question == null)
            {
                return BadRequest("The entity could not be found by id");
            }
            else
            {
                return Ok(question);            
            }
        }
    }
}
