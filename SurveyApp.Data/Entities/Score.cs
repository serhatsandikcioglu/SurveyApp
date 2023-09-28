using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Entities
{
    public class Score : BaseEntity<Guid>
    {
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NumberOfCorrectAnswer { get; set; }
    }
}
