using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.Entities;
using SurveyApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly DbSet<Question> _dbSet;

        public QuestionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Question>();
        }
    }
}
