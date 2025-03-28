using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Data.Interfaces;
using SurveyApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SurveyApp.Service.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public Guid Add(SurveyDTO survey)
        {
            Survey mappedSurvey = _mapper.Map<Survey>(survey);

            if (mappedSurvey.QuestionsId != null && mappedSurvey.QuestionsId.Any())
            {
                var questions = _unitOfWork.QuestionRepository.GetByIds(mappedSurvey.QuestionsId);
                mappedSurvey.Questions = questions;
            }

            _unitOfWork.SurveyRepository.Add(mappedSurvey);
            _unitOfWork.SaveChanges();
            return mappedSurvey.Id;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SurveyDTO>> GetAllByUserId(Guid id)
        {
            string cacheKey = $"Surveys_{id}";

            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonConvert.DeserializeObject<List<SurveyDTO>>(cachedData);
            }

            List<Survey> surveys = _unitOfWork.SurveyRepository.GetAllByUserId(id);
            var mappedSurveys = _mapper.Map<List<SurveyDTO>>(surveys);

            
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(mappedSurveys), cacheOptions);

            return mappedSurveys;
        }

        public SurveyDTO GetById(Guid id)
        {
            Survey survey = _unitOfWork.SurveyRepository.GetById(id);
            SurveyDTO surveyDTO = _mapper.Map<SurveyDTO>(survey);
            return surveyDTO;
        }
    }
}
