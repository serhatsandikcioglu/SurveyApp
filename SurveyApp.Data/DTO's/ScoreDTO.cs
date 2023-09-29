using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.DTO_s
{
    public class ScoreDTO
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NumberOfCorrectAnswer { get; set; }
    }
}
