using SurveyApp.Data.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Interfaces
{
    public interface ISurveyService
    {
        void Add(SurveyDTO survey);
        SurveyDTO GetById(Guid id);
        void Delete(Guid id);
    }
}
