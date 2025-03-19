using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        List<Question> GetAll(bool isConfirmed);
        List<Question> GetByIds(List<Guid> ids);
    }
}
