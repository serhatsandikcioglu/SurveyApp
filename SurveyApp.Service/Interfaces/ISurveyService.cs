using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Interfaces
{
    public interface ISurveyService
    {
        Guid Add(SurveyDTO survey);
        SurveyDTO GetById(Guid id);
        void Delete(Guid id);
        List<SurveyDTO> GetAllByUserId(Guid id);
    }
}
