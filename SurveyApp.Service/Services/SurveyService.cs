using AutoMapper;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Data.Interfaces;
using SurveyApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(SurveyDTO survey)
        {
            var mappedSurvey = _mapper.Map<Survey>(survey);
            _unitOfWork.SurveyRepository.Add(mappedSurvey);
            _unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public SurveyDTO GetById(Guid id)
        {
            var survey = _unitOfWork.SurveyRepository.GetById(id);
            var surveyDTO = _mapper.Map<SurveyDTO>(survey);
            surveyDTO.Questions = new List<QuestionDTO>();
            foreach (var questionId in surveyDTO.QuestionsId)
            {
                var question = _unitOfWork.QuestionRepository.GetById(questionId);
                var questionDTO = _mapper.Map<QuestionDTO>(question);
                surveyDTO.Questions.Add(questionDTO);
            }
            return surveyDTO;
        }
    }
}
