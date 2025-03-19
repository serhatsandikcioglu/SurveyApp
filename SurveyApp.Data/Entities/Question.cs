using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Entities
{
    public class Question : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public List<string> Choices { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public virtual List<Survey> Surveys { get; set; } = new();
    }
}
    