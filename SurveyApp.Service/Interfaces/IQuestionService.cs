using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Interfaces
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        void Delete(int id);
        void Update(QuestionDTO question);
        void Add(QuestionDTO question);
        Question GetById(int id);
    }
}
