using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Data.DTO_s;
using SurveyApp.Service.Interfaces;

namespace SurveyApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

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
            var questions = _questionService.GetAllConfirmedQuestion();

            return View(questions);
        }
        public IActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQuestion([FromForm] QuestionDTO question)
        {
            var validationResult = _questionValidator.Validate(question);
            if (validationResult.IsValid)
            {
            question.IsConfirmed = true;
            _questionService.Add(question);
            return RedirectToAction("Index");
            }
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(question);
        }
        public IActionResult UpdateQuestion([FromRoute(Name ="id")]Guid id)
        {
            var model = _questionService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateQuestion(QuestionDTO question)
        {
            var validationResult = _questionValidator.Validate(question);
            if (validationResult.IsValid)
            {
                question.IsConfirmed = true;
                _questionService.Update(question);
            return RedirectToAction("Index");
            }
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(question);
        }
        public IActionResult DeleteQuestion([FromRoute(Name = "id")] Guid id)
        {
            _questionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
