using QuizApp.Entity;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Interfaces.QuestionService
{
    public interface IQuestionService:IGenericService<Question>
    {
        QuestionWithAnswers GetQuestionWithAnswersById(int _id);
    }
}
