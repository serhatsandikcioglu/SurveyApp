using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.DTO_s
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<string> Choises { get; set; }
        public int? CorrectChoiseIndex { get; set; }
        public bool IsConfirmed { get; set; } = false;
    }
}
