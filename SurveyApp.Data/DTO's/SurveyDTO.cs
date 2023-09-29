using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.DTO_s
{
    public class SurveyDTO
    {
        public Guid Id { get; set; }
        public List<Guid> QuestionsId { get; set; }
        public Guid AppUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
