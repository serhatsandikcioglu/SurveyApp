using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Interfaces
{
    public interface IScoreRepository : IGenericRepository<Score>
    {
        List<Score> GetScoresBySurvey(Guid id);
        Score GetById(Guid id);
    }
}
