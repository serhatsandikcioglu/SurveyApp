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
    public class SurveyRepository : GenericRepository<Survey> , ISurveyRepository
    {
        private readonly DbSet<Survey> _dbSet;

        public SurveyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Survey>();
        }
        public Survey GetById(Guid id)
        {
            return _dbSet.Where(x=>x.Id == id).Include(x=>x.Questions).FirstOrDefault();
        }
    }
}
