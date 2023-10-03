using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Service.Interfaces;

namespace SurveyApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

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
        public IActionResult UpdateQuestion([FromRoute(Name = "id")] Guid id)
        {
            _questionService.AddToPool(id);
            TempData["success"] = "Question has been added to pool";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteQuestion([FromRoute(Name = "id")] Guid id)
        {
            _questionService.Delete(id);
            TempData["danger"] = "Question request has been deleted";
            return RedirectToAction("Index");
        }
    }
}
