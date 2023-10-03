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
    public class ScoreService : IScoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Add(ScoreDTO score)
        {
            var survey = _unitOfWork.SurveyRepository.GetById(score.SurveyId);
            for (int i = 0; i < survey.CorrectAnswerIndexes.Count; i++)
            {
                if (survey.CorrectAnswerIndexes[i] == score.UserAnswerIndexes[i])
                {
                    score.NumberOfCorrectAnswer++;
                }
            }
           var mappedScore = _mapper.Map<Score>(score);
            _unitOfWork.ScoreRepository.Add(mappedScore);
            _unitOfWork.SaveChanges();
            return mappedScore.Id;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ScoreDTO GetById(Guid id)
        {
            var score = _unitOfWork.ScoreRepository.GetById(id);
            return _mapper.Map<ScoreDTO>(score);
        }
        public List<ScoreDTO> GetScoresBySurvey(Guid id)
        {
           var scores = _unitOfWork.ScoreRepository.GetScoresBySurvey(id);
            var mappedScores = scores.Select(score => _mapper.Map<ScoreDTO>(score)).ToList();
            return mappedScores;
        }
        public bool IsThereLessThanFiveResult(Guid surveyId)
        {
           Survey survey = _unitOfWork.SurveyRepository.GetByIdWithUser(surveyId);
           int scoreCount = _unitOfWork.ScoreRepository.GetScoreCount(surveyId);
            if (survey.AppUser == null && scoreCount >= 5)
            {
                return false;
            }
            return true;
        }
    }
}
