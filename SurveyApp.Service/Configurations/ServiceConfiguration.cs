using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Data.Interfaces;
using SurveyApp.Data.Repositories;
using SurveyApp.Service.Interfaces;
using SurveyApp.Service.Mapper;
using SurveyApp.Service.Services;
using SurveyApp.Service.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SurveyApp.Service.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IValidator<QuestionDTO>, QuestionValidator>();
            services.AddScoped<IValidator<RegisterDTO>, RegisterValidator>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ISurveyRepository,SurveyRepository>();
            services.AddScoped<ISurveyService,SurveyService>();
            services.AddScoped<IScoreRepository,ScoreRepository>();
            services.AddScoped<IScoreService,ScoreService>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("SqlConnection"), action =>
                {
                    action.MigrationsAssembly("SurveyApp.Data");
                });

            });


        }

    }
}
