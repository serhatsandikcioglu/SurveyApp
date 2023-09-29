using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(AppDbContext appDbContext, IServiceProvider serviceProvider)
        {
            _appDbContext = appDbContext;
            _serviceProvider = serviceProvider;
        }
        private IQuestionRepository _questionRepository ;
        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == default(IQuestionRepository))
                    _questionRepository = _serviceProvider.GetRequiredService<IQuestionRepository>();
                return _questionRepository;
            }

        }
        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
