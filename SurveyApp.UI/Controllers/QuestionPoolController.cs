using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Service.Interfaces;
using SurveyApp.Service.Validator;

namespace SurveyApp.UI.Controllers
{
    public class QuestionPoolController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IValidator<QuestionDTO> _questionValidator;

        public QuestionPoolController(IQuestionService questionService, IValidator<QuestionDTO> questionValidator)
        {
            _questionService = questionService;
            _questionValidator = questionValidator;
        }

        public IActionResult Index()
        {
            List<QuestionDTO> questions = _questionService.GetAllConfirmedQuestion();

            return View(questions);
        }
        public IActionResult SendRequest()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult SendRequest([FromForm] QuestionDTO question )
        {
            var validationResult = _questionValidator.Validate(question);
            if (validationResult.IsValid)
            {
                _questionService.Add(question);
                TempData["success"] = "Question request has been sended to admin";
                return RedirectToAction("Index");
            }
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(question);
        }
    }
}
