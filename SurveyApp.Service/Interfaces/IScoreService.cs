using SurveyApp.Data.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Interfaces
{
    public interface IScoreService
    {
        void Add(ScoreDTO score);
        ScoreDTO GetById(Guid id);
        void Delete(Guid id);
        List<ScoreDTO> GetScoresBySurvey(Guid id);
        bool IsThereLessThanFiveResult(Guid surveyId);
    }
}
