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
            var mappedQuestion =  _mapper.Map<Question>(question);
            _unitOfWork.QuestionRepository.Add(mappedQuestion);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.QuestionRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public List<Question> GetAll()
        {
           return _unitOfWork.QuestionRepository.GetAll();
        }

        public Question GetById(int id)
        {
            return _unitOfWork.QuestionRepository.GetById(id);
        }

        public void Update(QuestionDTO question)
        {
            var mappedQuestion = _mapper.Map<Question>(question);
            _unitOfWork.QuestionRepository.Add( mappedQuestion);
            _unitOfWork.SaveChanges();
        }
    }
}
