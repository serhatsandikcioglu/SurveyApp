using AutoMapper;
using FluentValidation;
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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(QuestionDTO question)
        {
            Question mappedQuestion =  _mapper.Map<Question>(question);
            _unitOfWork.QuestionRepository.Add(mappedQuestion);
            _unitOfWork.SaveChanges();
            
        }

        public void AddToPool(Guid id)
        {
           Question question = _unitOfWork.QuestionRepository.GetById(id);
            question.IsConfirmed = true;
            _unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Question question = _unitOfWork.QuestionRepository.GetById(id);
            if (question != null)
            {
                _unitOfWork.QuestionRepository.Delete(id);
                _unitOfWork.SaveChanges();
            }
        }

        public List<QuestionDTO> GetAllConfirmedQuestion()
        {
            List<Question> questions = _unitOfWork.QuestionRepository.GetAll(true);
            return _mapper.Map<List<QuestionDTO>>(questions);
        }
        public List<QuestionDTO> GetAllNotConfirmedQuestion()
        {
            List<Question> questions = _unitOfWork.QuestionRepository.GetAll(false);
            return _mapper.Map<List<QuestionDTO>>(questions);
        }
        public List<QuestionDTO> GetFirst10Question()
        {
            List<Question> questions = _unitOfWork.QuestionRepository.GetFirst10Question();
            return _mapper.Map<List<QuestionDTO>>(questions);
        }
        public QuestionDTO GetById(Guid id)
        {
            Question question = _unitOfWork.QuestionRepository.GetById(id);
            return _mapper.Map<QuestionDTO>(question);
        }

        public void Update(QuestionDTO question)
        {
            Question mappedQuestion = _mapper.Map<Question>(question);
            _unitOfWork.QuestionRepository.Update( mappedQuestion);
            _unitOfWork.SaveChanges();
        }
        public List<QuestionDTO> GetQuestionList(QuestionModel model)
        {
               List<Question> questions = _unitOfWork.QuestionRepository.GetByIds(model.selectedQuestions);
            return _mapper.Map<List<QuestionDTO>>(questions);
        }
    }
}
