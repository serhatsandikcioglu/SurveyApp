using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        IQuestionRepository QuestionRepository { get; }
    }
}
