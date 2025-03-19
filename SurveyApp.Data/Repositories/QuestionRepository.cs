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

        public List<Question> GetAll(bool isConfirmed)
        {
            if (isConfirmed == true)
            {
               return _dbSet.Where(x => x.IsConfirmed == true).ToList();
            }
            return _dbSet.Where(x=>x.IsConfirmed == false).ToList();
        }

        public List<Question> GetByIds(List<Guid> ids)
        {
            return _dbSet.Where(q => ids.Contains(q.Id)).ToList();
        }
    }
}
