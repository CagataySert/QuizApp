using QuizApp.Entity;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Interfaces.AnswerService
{
    public interface IAnswerService:IGenericService<Answer>
    {
        List<Answer> GetAnswerByQuestionId(int _id);
    }
}
