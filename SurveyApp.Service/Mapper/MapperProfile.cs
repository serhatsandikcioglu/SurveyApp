using AutoMapper;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<AspNetUser,RegisterDTO>().ReverseMap();
            CreateMap<Survey, SurveyDTO>().ReverseMap();
            CreateMap<Score, ScoreDTO>().ReverseMap();
        }
        
    }
}
