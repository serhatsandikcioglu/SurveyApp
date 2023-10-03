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
    public class ScoreRepository : GenericRepository<Score>, IScoreRepository
    {
        private readonly DbSet<Score> _dbSet;

        public ScoreRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Score>();
        }
        public Score GetById(Guid id)
        {
            return _dbSet.Where(x => x.Id == id).Include(x => x.Survey).FirstOrDefault();
        }
        public List<Score> GetScoresBySurvey(Guid id)
        {
            return _dbSet.Where(x => x.SurveyId == id).Include(x=>x.Survey).ToList();
        }
        public int GetScoreCount(Guid id)
        {
            return _dbSet.Count(x => x.SurveyId == id);
        }
    }
}
