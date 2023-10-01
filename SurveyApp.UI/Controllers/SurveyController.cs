using Microsoft.AspNetCore.Mvc;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.DTO_s;
using SurveyApp.Service.Interfaces;

namespace SurveyApp.UI.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IQuestionService _questionService;

        public SurveyController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            var questions = _questionService.GetAllConfirmedQuestion().ToList();
            return View(questions);
        }
        [HttpPost]
        public IActionResult CreateSurvey()
        {
            return RedirectToAction();
        }
        [HttpPost]
        public IActionResult AddQuestionToSurvey()
        {
            return RedirectToAction("Suvey");
        }
    }
}
