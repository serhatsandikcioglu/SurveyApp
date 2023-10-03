using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Interfaces
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        Survey GetById(Guid id);
        List<Survey> GetAllByUserId(Guid id);
        Survey GetByIdWithUser(Guid id);
    }
}
