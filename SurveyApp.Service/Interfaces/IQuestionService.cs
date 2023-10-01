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
        List<QuestionDTO> GetAllConfirmedQuestion();
        List<QuestionDTO> GetAllNotConfirmedQuestion();
        void Delete(Guid id);
        void Update(QuestionDTO question);
        void Add(QuestionDTO question);
        QuestionDTO GetById(Guid id);
        void AddToPool(Guid id);
    }
}
