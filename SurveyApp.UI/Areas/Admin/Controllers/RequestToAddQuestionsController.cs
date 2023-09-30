using Microsoft.AspNetCore.Mvc;
using SurveyApp.Service.Interfaces;

namespace SurveyApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestToAddQuestionsController : Controller
    {
        private readonly IQuestionService _questionService;

        public RequestToAddQuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        public IActionResult Index()
        {
            var questions = _questionService.GetAllNotConfirmedQuestion();
            return View(questions);
        }
    }
}
