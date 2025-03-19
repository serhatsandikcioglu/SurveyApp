using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Entities
{
    public class Survey : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Guid> QuestionsId { get; set; }
        public virtual List<Question> Questions { get; set; }
        public List<int> CorrectAnswerIndexes { get; set; }
        public Guid? AppUserId { get; set; }
        public AspNetUser? AppUser { get; set; }
        public DateTime CreatedDate { get; private set; }

        public Survey()
        {
            CreatedDate = DateTime.UtcNow;
            Questions = new List<Question>(); 
            QuestionsId = new List<Guid>(); 
            CorrectAnswerIndexes = new List<int>();
        }
    }


    
}
